using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT_Form
{
    public partial class Form1 : Form
    {
        MqttClient client;
        public Form1()
        {
            InitializeComponent();

            // instantiate a new client instance whose constructor takes the args of the broker ip

             client = new MqttClient("192.168.1.9");

            
        }

        private void Form1_Load(object sender,EventArgs e)
        {

        }

        private void btnPublish_Click(object render, EventArgs e)
        {

            // anyone that tries to connect to the broker must have a valid id
            // here we generate a new id for our client
            string clientId = Guid.NewGuid().ToString();

            // then we connect using the client id we generated 
            client.Connect(clientId);

            // then we need to subscribe to the topic that the publisher offers (temprature for example)
            string content = tbContent.Text;

            client.Publish("home/room/light", Encoding.UTF8.GetBytes(content), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);



        }
    }
}
