using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarChessConn3ct
{
    public partial class Login : Form
    {
        static Login fLoginBox;
        static DialogResult result = DialogResult.None;

        public Login()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            fLoginBox = new Login();
            fLoginBox.ShowDialog();
            return result;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            Main.nickname = nicknameBox.Text;
            Main.channel = roomBox.Text;
            fLoginBox.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 3; i++)
                nicknameBox.AppendText(r.Next(10).ToString());
            for (int i = 0; i < 3; i++)
                roomBox.AppendText(r.Next(10).ToString());
        }
    }
}
