/*  ----------------------------------------------------------------------------
 *  Copyright (c) 2012-2013 George Mason University
 *  George Mason University
 *  ----------------------------------------------------------------------------
 *  Developed by: Christopher E. Everett; Damon McCoy; Parnian Najafi.
 *  ----------------------------------------------------------------------------
 *  Open Car Testbed and Network Experiments (OCTANE)
 *  ----------------------------------------------------------------------------
 *  File:       XML-Interface.cs
 *  Author:     autolab-everett\ceveret3
 *  ----------------------------------------------------------------------------
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.

 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

//using System.Diagnostics;



namespace OpenCarTestbed
{
    class XMLInterfaces
    {

        // ***********************
        // Filter List
        //************************

        // Returns a string array of the Cars
        public static string[] ReturnCarTypes()
        {
            // The variable length List for returning the string array
            List<string> cartypes = new List<string>();

            try
            {
                XDocument doc = XDocument.Load(ConfigFiles.Settings1.Default.filterURI);

                // Searches for the elements named CarName
                var cars = doc.Descendants("CarName");

                foreach (var car in cars)
                {
                    cartypes.Add(car.Value);
                }

                string[] array = cartypes.ToArray();
                return array;
            }
            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }
        }

        // Searches for the ID of the carType
        public static string ReturnID(string cartype, int id)
        {
            // Puts the id into a hex format for comparison to the XML file
            string stringid = String.Format("{0:X}", id);

            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);

                // Error Checking -- very clunky; revisions needed; returns ?? if the CarName does not exist
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return "??";
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();


                //if (cartypeElement.Elements("ECU").Where(e3 => e3.Element("ID").Value.Contains("?")) != null)
                //     || e3.Element("ID").Value.Contains("*") || e3.Element("ID").Value.Contains("[")) != null)
                //    return "wildcard";


                if (cartypeElement.Elements("ECU").Where(e3 => e3.Element("ID").Value.Equals(stringid)).FirstOrDefault() == null)
                    return "??";
                var ecuElement = cartypeElement.Elements("ECU").Where(e3 => e3.Element("ID").Value.Equals(stringid)).FirstOrDefault();

                if (ecuElement.Element("Name").Value == null)
                    return "??";
                var nameElement = ecuElement.Element("Name").Value;

                return nameElement.ToString();
            }
            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }
        }

        // Searches for the message of the cartype
        public static string ReturnMsg(string cartype, string stringmsg)
        {
            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);

                // Error Checking -- very clunky; needs revisions
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return "??";
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();

                if (cartypeElement.Elements("MSG").Where(e3 => e3.Element("Message").Value.Equals(stringmsg)).FirstOrDefault() == null)
                    return "??";
                var msgElement = cartypeElement.Elements("MSG").Where(e3 => e3.Element("Message").Value.Equals(stringmsg)).FirstOrDefault();

                if (msgElement.Element("Name").Value == null)
                    return "??";

                var nameElement = msgElement.Element("Name").Value;  
                return nameElement.ToString();
            }
            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }
        }

        // Searches for the packet of the cartype
        public static string ReturnPacketIdentifier(string cartype, int id, string stringmsg)
        {
            string stringid = String.Format("{0:X}", id);

            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);

                // Error Checking -- very clunky; needs revisions
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return "??";
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();


                if (cartypeElement.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
                    && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() == null)
                    return "??";
                var msgElement = cartypeElement.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
                    && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (msgElement.Element("Name").Value == null)
                    return "??";
                var nameElement = msgElement.Element("Name").Value;

                return nameElement.ToString();
            }
            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }
        }


        /*
        // Searches for the if then packet of the cartype
        public static void CheckIfThen(string cartype, int id, string stringmsg)
        {
            string stringid = String.Format("{0:X}", id);

            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);

                // Error Checking -- very clunky; needs revisions
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return;
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();

                var cars = cartypeElement.Elements("IFTHEN");
                foreach (var car in cars)
                {
                    if (car.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
    && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                    {
                        var msgElement = car.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
                            && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    }
                }

                
                if (cartypeElement.Elements("IFTHEN").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                    return cartypeElement.Elements("IFTHEN").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().ToString();

                if (cartypeElement.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
                    && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() == null)
                    return;
                var msgElement = cartypeElement.Elements("Packet").Where(e3 => e3.Element("Message").Value.Equals(stringmsg, StringComparison.OrdinalIgnoreCase)
                && e3.Element("ID").Value.Equals(stringid, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (msgElement.Element("Name").Value == null)
                    return;
                var nameElement = msgElement.Element("Name").Value;
                 

                return;
            }
            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return;
            }
        }

*/

        // Adds a Cartype to the XML
        public static void AddVehicle(string cartype)
        {
            try
            {
                // Loads the XML file
                XDocument xmlDoc = XDocument.Load(ConfigFiles.Settings1.Default.filterURI);

                // Adds the new cartype to the loaded XML
                xmlDoc.Element("Cars").Add(new XElement("CarType", new XElement("CarName", cartype)));

                // Saves the XML file
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

        // Deletes a Cartype to the XML
        public static void DeleteVehicle(string cartype)
        {
            try
            {
                // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);

                // Searches for the node with the CarName and then deletes the parent node
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", cartype));
                node.ParentNode.RemoveChild(node);

                // Saves the XML file
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

        public static void RenameVehicle(string cartype, string carname)
        {
            try{
            // Loads the XML file
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFiles.Settings1.Default.filterURI);

                // Searches for the node with the CarName and then deletes the parent node
                //var matchingElement = (from s in xmlDoc.Elements("Cars")
                //                       where CarType.Element("CarName").Value == cartype
                //                       select s).FirstOrDefault();
                XmlNode node = xmlDoc.SelectSingleNode(String.Format("/Cars/CarType[CarName = '{0}']", cartype));
                //node.ParentNode.ReplaceChild(
                node["CarName"].InnerText = carname;
                    //InnerText = cartype;
                //node.ParentNode.RemoveChild(node);
                // xmlDoc.Element("Cars").Add(new XElement("CarType", new XElement("CarName", cartype)));

                // Saves the XML file
                xmlDoc.Save(ConfigFiles.Settings1.Default.filterURI);
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
            }
        }

        // Searches for the ECUs of the carType
        public static ListViewItem[] ReturnECU(string cartype)
        {

            return null;
            
            // Puts the id into a hex format for comparison to the XML file
            
            /*string stringid = String.Format("{0:X}", id);

            
            XElement carElement = XElement.Load(uri);

            // Error Checking -- very clunky; revisions needed; returns ?? if the CarName does not exist
            if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                return "??";

            var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();


            if (cartypeElement.Elements("ECU").Where(e3 => e3.Element("ID").Value.Equals(stringid)).FirstOrDefault() == null)
                return "??";

            var ecuElement = cartypeElement.Elements("ECU").Where(e3 => e3.Element("ID").Value.Equals(stringid)).FirstOrDefault();

            if (ecuElement.Element("Name").Value == null)
                return "??";

            var nameElement = ecuElement.Element("Name").Value;
            return nameElement.ToString();
           */
        }

        // Edits the cartypes
        public static void EditVehicle(string cartype)
        {

        }




        // ***********************
        // Custom Transmit
        //************************



        //***********************
        // Returns the various Transmit Types for the Custom Transmit Button Generation
        //***********************

        public static string[] ReturnTransmitTypes(string path)
        {
            // The variable length List for returning the string array
            List<string> cartypes = new List<string>();

            try
            {

                // load xml document
                XDocument doc = XDocument.Load(path);//ConfigFiles.Settings1.Default.filterURI);

                // Searches for the elements named CarName
                var cars = doc.Descendants("CarName");

                foreach (var car in cars)
                {
                    cartypes.Add(car.Value);
                }

                string[] array = cartypes.ToArray();
                return array;
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }
        }

        public static string[] ReturnPackets(string carname)
        {
            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);
                List<string> packets = new List<string>();

                // Error Checking -- very clunky; revisions needed
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(carname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() == null)
                    return null;

                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(carname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();


                // For the Packet Types
                //var cars = cartypeElement.Descendants("Packet");
                var cars = cartypeElement.Elements("Packet");
                foreach (var car in cars)
                    packets.Add((string)car.Element("Name") + "; Packet");

                // For the Sequence Types
                cars = cartypeElement.Elements("Sequence");
                foreach (var car in cars)
                    packets.Add((string)car.Element("Name") + "; Sequence");

                // For the IF THEN Types
                cars = cartypeElement.Elements("IFTHEN");
                foreach (var car in cars)
                    packets.Add((string)car.Element("Name") + "; If Then");

                return packets.ToArray();
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }

        }

        // Returns Data for the selected packet from the xml file
        public static string ReturnPacketDataDisplay(string cartype, string packetname)
        {
            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);
                List<string> packets = new List<string>();

                // Error Checking -- very clunky; needs revisions
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return "??";
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();


                // Error Checking -- very clunky; needs revisions
                if (cartypeElement.Elements("Packet").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                    return cartypeElement.Elements("Packet").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().ToString();
                // Looping through the types; Needs revisions to pull all elements
                else if (cartypeElement.Elements("Sequence").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                    return cartypeElement.Elements("Sequence").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().ToString();
                else if (cartypeElement.Elements("IFTHEN").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                    return cartypeElement.Elements("IFTHEN").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().ToString();
                else
                    return "??";
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return "??";
            }

        }


        // Returns Data for the selected packet from the xml file
        public static string ReturnPacketDataTransmit(string cartype, string packetname)
        {
            // return string --> 0=id; 1=dlc; 2=flag; 3=message
            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);
                List<string> packets = new List<string>();

                // Error Checking -- very clunky; needs revisions
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return "??";
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();


                // Error Checking -- very clunky; needs revisions
                if (cartypeElement.Elements("Packet").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null){

                   var car = cartypeElement.Elements("Packet").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    //return (string)car.Element("Name") + ";" 
                        return (string)car.Element("ID") + ";" 
                        + (string)car.Element("DLC") + ";"
                        + (string)car.Element("Flag") + ";"
                        + (string)car.Element("Message") + ";"
                        + (string)car.Element("Count") + ";"
                        + (string)car.Element("TimeBetween");

                } else 
                    return "??";
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }

        }


        // Returns Data for the selected packet from the xml file
        public static string ReturnPacketDataSequence(int count, string cartype, string packetname)
        {
            // return string --> 0=id; 1=dlc; 2=flag; 3=message
            try
            {
                XElement carElement = XElement.Load(ConfigFiles.Settings1.Default.filterURI);
                List<string> packets = new List<string>();

                // Error Checking -- very clunky; needs revisions
                if (carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault() == null)
                    return "??";
                var cartypeElement = carElement.Descendants("CarType").Where(e2 => e2.Element("CarName").Value.Equals(cartype)).FirstOrDefault();

              //  MainWindow.ErrorDisplayString("Level One:" + cartypeElement.ToString());

                // Error Checking -- very clunky; needs revisions
                if (cartypeElement.Elements("Sequence").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                {

                    var sequencetypeElements = cartypeElement.Elements("Sequence").Where(e3 => e3.Element("Name").Value.Equals(packetname, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                   // MainWindow.ErrorDisplayString("Level Two:" + sequencetypeElements.ToString());

                    // Error Checking -- very clunky; needs revisions
                    if (sequencetypeElements.Elements("Packet").Where(e3 => e3.Element("Number").Value.Equals(Convert.ToString(count), StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null)
                    {
                        var car = sequencetypeElements.Elements("Packet").Where(e3 => e3.Element("Number").Value.Equals(Convert.ToString(count), StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                       // MainWindow.ErrorDisplayString("Level Three:" + car.ToString());

                        return (string)car.Element("ID") + ";"
                        + (string)car.Element("DLC") + ";"
                        + (string)car.Element("Flag") + ";"
                        + (string)car.Element("Message");
                    }
                }
                
                return "??";
            }

            //catch (FileNotFoundException)
            catch (Exception)
            {
                ErrorLog.NewLogEntry("Filter", "URI filename not found");
                return null;
            }

        }

    }
}