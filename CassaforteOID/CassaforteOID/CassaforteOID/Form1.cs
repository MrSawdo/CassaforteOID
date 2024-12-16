namespace CassaforteOID
{
    public partial class Form1 : Form
    {
        private Cassaforte cassaforte1;

        public Form1()
        {
            InitializeComponent();
            cassaforte1 = new Cassaforte("00001", "Oulib", "padel", "ouldib123456");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Stato();
            TentativiSblocco();
        }

        public void Stato()
        {
            if (cassaforte1.Blocco == true)
            {
                statoCassaforteLBL.Text = "BLOCCATA";
                statoCassaforteLBL.ForeColor = Color.Cornsilk;
            }
            else if (cassaforte1.Blocco == false)
            {
                if (cassaforte1.Stato == true)
                {
                    statoCassaforteLBL.Text = "APERTA";
                    statoCassaforteLBL.ForeColor = Color.Green;
                }
                else
                {
                    statoCassaforteLBL.Text = "CHIUSA";
                    statoCassaforteLBL.ForeColor = Color.Red;
                }
            }
        }

        public void TentativiSblocco()
        {
            label8.Text = Convert.ToString(cassaforte1.TentativiDiSblocco);
        }

        private void statoCassaforteLBL_Click(object sender, EventArgs e)
        {

        }
        //impostazione del codice utente
        private void impostaCodUtenteBTN_Click_1(object sender, EventArgs e)
        {
            bool controllo = false;
            if (impostaCodUtente.Text.Length != 5)
                return;
            for (int i = 0; i < impostaCodUtente.Text.Length; i++)
            {
                if (impostaCodUtente.Text[i] <= '0' && impostaCodUtente.Text[i] >= '9')
                    controllo = true;
            }
            if (controllo == false)
            {
                cassaforte1.ImpostaCodiceUtente(impostaCodUtente.Text);
                MessageBox.Show(impostaCodUtente.Text);
                impostaCodUtenteBTN.Visible = false;
                impostaCodUtente.Visible = false;
            }
        }

        //impostazione della data
        private void impostaDataBTN_Click_1(object sender, EventArgs e)
        {
            cassaforte1.ImpostaData(impostaData.Text);
            impostaDataBTN.Visible = false;
            impostaData.Visible = false;
            Data.Text = Convert.ToString(cassaforte1.DataProgrammata);
        }
        //chiudi la cassaforte
        private void BloccaBTN_Click_1(object sender, EventArgs e)
        {
            cassaforte1.ChiudiCassaforte();
            Stato();
        }

        //inserisci il codice universale
        private void inserisciCodUniversaleBTN_Click_1(object sender, EventArgs e)
        {
            if (inserisciCodUniversale.Text.Length != 12)
            {
                return;
            }
            else if (cassaforte1.CodiceSblocco == null || inserisciData.Text != impostaData.Text)
            {
                return;
            }
            else if (cassaforte1.CodiceSblocco != null && inserisciData.Text == impostaData.Text)
            {
                cassaforte1.SbloccaCassaforte(inserisciCodUniversale.Text);
                Stato();
                TentativiSblocco();
            }
        }

        //inserisci la data
        private void inserisciDataBTN_Click_1(object sender, EventArgs e)
        {
            cassaforte1.AperturaProgrammata(inserisciData.Text, inserisciCodUtente.Text);
            Stato();
            TentativiSblocco();
        }

        //inserisci il codice utente
        private void inserisciCodUtenteBTN_Click_1(object sender, EventArgs e)
        {
            if (inserisciCodUtente.Text.Length != 5)
                return;
            if (cassaforte1.CodiceUtente != null)
            {
                cassaforte1.ApriCassaforte(inserisciCodUtente.Text);
                Stato();
                TentativiSblocco();
            }
        }
    }
}
