using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQTT_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate a new client instance whose constructor takes the args of the broker ip

            MqttClient client = new MqttClient("192.168.1.9");

            // the client fires an event of what will happen whenever it recives a message
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

            // anyone that tries to connect to the broker must have a valid id
            // here we generate a new id for our client
            string clientId = Guid.NewGuid().ToString();

            // then we connect using the client id we generated 
            client.Connect(clientId);

            // then we need to subscribe to the topic that the publisher offers (temprature for example)

            client.Subscribe(new String[] { "home/room/light" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });



        }

        private static void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            string msg = System.Text.Encoding.Default.GetString(e.Message); 
            Console.WriteLine(msg);
        }
    }
}
