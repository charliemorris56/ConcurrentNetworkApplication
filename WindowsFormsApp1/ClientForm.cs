using Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        private Client m_Client;

        public ClientForm(Client client)
        {
            InitializeComponent();
            m_Client = client;
        }


        public void UpdateChatWindow(string message)
        {
            if (MessageWindow.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UpdateChatWindow(message);
                }));
            }
            else
            {
                MessageWindow.Text += message + Environment.NewLine;
                MessageWindow.SelectionStart = MessageWindow.Text.Length;
                MessageWindow.ScrollToCaret();
            }
        }

        public void UpdatePeopleList(string message)
        {
            if (PeopleList.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UpdatePeopleList(message);
                }));
            }
            else
            {
                PeopleList.Text = "";
                PeopleList.Text += message + Environment.NewLine;
                PeopleList.SelectionStart = PeopleList.Text.Length;
                PeopleList.ScrollToCaret();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //UpdateChatWindow("You said: " + InputField.Text);
            Console.WriteLine("You said: " + InputField.Text);

            m_Client.TcpSendMessage(new ChatMessagePacket(InputField.Text));
            InputField.Text = ""; //Use this to clear the text input window
        }

        private void NameButton_Click(object sender, EventArgs e)
        {
            UpdateChatWindow("Your Name: " + NameInput.Text);

            m_Client.TcpSendMessage(new ClientNamePacket(NameInput.Text));
        }

        private void PeopleButton_Click(object sender, EventArgs e)
        {

        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            //m_Client.Close();
            Close(); // Close down the window
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            m_Client.RunGame();
        }
    }
}