using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace OpenCarTestbed.Common
{
    // Class if to handle the if then xml machine
    class IfThenXML
    {

        // Holds the dictionary of IfThen packets and the states
        enum State
        {
            If,
            IfSequence,
            Then
        };
        private Dictionary<string, State> IfThenPackets = new Dictionary<string, State>();

        // initialies the If Then Machine
        public void StartIfThenMachine(string carname)
        {

            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);

                // Error Checking -- very clunky; revisions needed
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(carname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() == null)
                    return;

                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(carname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                // For the IF THEN Types
                var cars = cartypeElement.Elements("IFTHEN");
                foreach (var car in cars)
                    IfThenPackets.Add((string)car.Element("Name"), State.If);
              
                return;
            }

            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return;
            }
        }

        // Stops the if then machine
        public void StopIfThenMachine()
        {
            IfThenPackets.Clear();
        }

        
        // Updates the if then machine based on received message
        public string UpdateIfThenMachine(CanData can, string cartype)
        {
            // setups the can information for string comparison to the XML
            string stringid = String.Format("{0:X}", can.id);
            string stringmsg = CommonUtils.ConvertMsgtoString(can.msg, can.dlc);

            // Cycles through the dictionary of ifthens
            foreach (KeyValuePair<string, State> pair in IfThenPackets)
            {
                // if in the if state then proceed with message matching
                if (pair.Value == State.If)
                {
                   // MainWindow.ErrorDisplayString("In Update IfThen: dictionary -- " + pair.Key);

                    // compares can message in xml to received can message
                    try
                    {
                        XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);

                        // Error Checking -- very clunky; needs revisions
                        if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                            return null;
                        var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();
                        //MainWindow.ErrorDisplayString("1:" + cartypeElement.ToString());


                        // ************************
                        // Needs to cycle through all of the If thens so that the if and thens can be properly synced together
                        // ************************


                        // Error Checking -- very clunky; needs revisions
                        if (cartypeElement.Elements("IFTHEN").Where(e2 => e2.Element("Name").Value.Equals(pair.Key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() == null)
                            return null;
                        var ifthenElement = cartypeElement.Elements("IFTHEN").Where(e2 => e2.Element("Name").Value.Equals(pair.Key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        //MainWindow.ErrorDisplayString("2:" + ifthenElement.ToString());

                        if (ifthenElement.Elements("If") == null)
                            return null;
                        var packetElement = ifthenElement.Elements("If");
                        //MainWindow.ErrorDisplayString("3:" + packetElement.ToString());

                        if (packetElement.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
            && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                        {
                            var msgElement = packetElement.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
                                    && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();


                            if (ifthenElement.Elements("Then") == null)
                                return null;
                            var responseElement = ifthenElement.Elements("Then");

                            if (responseElement.Elements("Packet") == null)
                                return null;
                            //var responsePacketElement = responseElement.Descendants("Packet");
                            var responsePacketElement = responseElement.Elements("Packet").FirstOrDefault();

                            return (string)responsePacketElement.Element("ID") + ";"
                                + (string)responsePacketElement.Element("DLC") + ";"
                                + (string)responsePacketElement.Element("Flag") + ";"
                                + (string)responsePacketElement.Element("Message");

                        }

                        return null;
                   
                    }
                    //catch (FileNotFoundException)
                    catch (Exception)
                    {
                        ErrorLog.NewLogEntry("Filter", "URI filename not found");
                        return null;
                    }

                }
            }

            return null;
        }


    }


}
