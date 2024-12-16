using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassaforteOID
{
    internal class Cassaforte
    {
        private string numeroSeriale;
        private string produttore;
        private string codiceSblocco;
        private bool stato;
        private string modello;
        private bool blocco;
        private string codiceUtente;
        private int tentativiDiSblocco = 0;
        private string dataProgrammata;

        public string NumeroSeriale
        {
            get { return numeroSeriale; }
        }
        public string Produttore
        {
            get { return produttore; }
        }

        public string Modello
        {
            get { return modello; }
        }

        public string CodiceSblocco
        {
            get { return codiceSblocco; }
        }
        public bool Stato
        {
            get { return stato; }
            set { stato = value; }
        }
        public bool Blocco
        {
            get { return blocco; }
            set { blocco = value; }
        }

        public string CodiceUtente
        {
            get { return codiceUtente; }
        }
        public int TentativiDiSblocco
        {
            get { return tentativiDiSblocco; }
            set { tentativiDiSblocco = value; }
        }
        public string DataProgrammata
        {
            get { return dataProgrammata; }
            set { dataProgrammata = value; }
        }

        public Cassaforte(string numeroSeriale, string produttore, string modello, string codiceSblocco)
        {
            this.numeroSeriale = numeroSeriale;
            this.produttore = produttore;
            this.modello = modello;
            if (codiceSblocco.Length != 12)
            {
                return;
            }
            else
            {
                this.codiceSblocco = codiceSblocco;
            }
            this.stato = false;
            this.blocco = false;
        }

        public void ImpostaCodiceUtente(string codice)
        {
            if (codice.Length != 5)
            {
                return;
            }
            else
            {
                codiceUtente = codice;
            }
        }

        public void ApriCassaforte(string codice)
        {
            if (blocco == true)
            {
                return;
            }
            if (codice != codiceUtente)
            {
                TentativiDiSblocco++;
                if (TentativiDiSblocco == 4)
                {
                    blocco = true;
                }
                return;
            }
            Stato = true;
        }

        public void ChiudiCassaforte()
        {
            Stato = false;
        }

        public void SbloccaCassaforte(string codice)
        {
            if (codice != codiceSblocco)
            {
                return;
            }
            else
            {
                Blocco = false;
                TentativiDiSblocco = 0;
                Stato = true;
            }
        }

        public void ImpostaData(string data)
        {
            if (data != null)
            {
                dataProgrammata = data;
            }
        }

        public void AperturaProgrammata(string data, string codice)
        {
            if (blocco == true)
            {
                return;
            }
            else if (codice != codiceUtente || data != dataProgrammata)
            {
                TentativiDiSblocco++;
                if (TentativiDiSblocco == 4)
                {
                    blocco = true;
                }
                return;
            }
            else
            {
                Stato = true;
            }
        }
    }
}
