using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Scadenziario_MCG.Pages.Tipologie
{
    public class IndexModel : PageModel
    {
        public List<ListaScadenze> Scadenzes = new List<ListaScadenze>();
        public void OnGet()
        {
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS; Database=Scadenziario; Trusted_connection=true";
            string strSql = "SELECT * From Scadenze";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSql;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListaScadenze scadenze = new ListaScadenze();
                scadenze.CodiceTipologiaScadenza = reader.GetString(0);
                scadenze.DescrizioneTipologia = reader.GetString(1);
                scadenze.TipoAnagrafica = reader.GetString(2);
                scadenze.Gruppo = reader.GetString(3);
                scadenze.Anagrafica = reader.GetString(4);
                scadenze.ManutenzioneMacchina = reader.GetString(5);
                scadenze.AvvisoScadenza = reader.GetString(6);
                scadenze.AvvisoInvioEmail = reader.GetString(7);
                scadenze.MittenteNome = reader.GetString(8);
                scadenze.MittenteIndirizzo = reader.GetString(9);
                scadenze.TestoEmail = reader.GetString(10);
                scadenze.Ricorrente = reader.GetString(11);
                scadenze.FormulaRinnovoScadenza = reader.GetString(12);
                Scadenzes.Add(scadenze);
            }
            conn.Close();
        }
        public class ListaScadenze
        {
            public string CodiceTipologiaScadenza;
            public string DescrizioneTipologia;
            public string TipoAnagrafica;
            public string Gruppo;
            public string Anagrafica;
            public string ManutenzioneMacchina;
            public string AvvisoScadenza;
            public string AvvisoInvioEmail;
            public string MittenteNome;
            public string MittenteIndirizzo;
            public string TestoEmail;
            public string Ricorrente;
            public string FormulaRinnovoScadenza;
        }
    }
}
