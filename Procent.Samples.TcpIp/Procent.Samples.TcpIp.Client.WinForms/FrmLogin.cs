using System.Windows.Forms;

namespace Procent.Samples.TcpIp.Client.WinForms
{
	public partial class FrmLogin : Form
	{
		public int Id
		{
			get { return int.Parse(tbId.Text); }
		}

		public string Password
		{
			get { return tbPassword.Text; }
		}

		public FrmLogin()
		{
			InitializeComponent();
		}

		private void tbId_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsNumber(e.KeyChar));
		}

		private void tbValidation_NumberEntered(object sender, System.ComponentModel.CancelEventArgs e)
		{
			int i;
			e.Cancel = !int.TryParse(((TextBox)sender).Text, out i);
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}