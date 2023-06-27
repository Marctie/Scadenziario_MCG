using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Scadenziario_MCG.Pages.Tipologie
{
    public class EditModel : PageModel
    {
        public List<ListaScadenze> Scadenzes = new List<ListaScadenze>();
        public ListaScadenze Scadenze = new ListaScadenze();
        public void OnGet()
        {
            string CTS = Request.Query["CodiceTipologiaScadenza"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS; Database=Scadenziario; Trusted_connection=true";
            string strSql = "SELECT * From Scadenze WHERE CodiceTipologiaScadenza=@CodiceTipologiaScadenza";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSql;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("CodiceTipologiaScadenza", CTS);
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

        public void OnPost()
        {
            Scadenze.CodiceTipologiaScadenza = Request.Form["textboxCTS"];
            Scadenze.DescrizioneTipologia = Request.Form["textboxDT"];
            Scadenze.TipoAnagrafica = Request.Form["textboxTAna"];
            Scadenze.Gruppo = Request.Form["textboxGruppo"];
            Scadenze.Anagrafica = Request.Form["textboxAna"];
            Scadenze.ManutenzioneMacchina = Request.Form["textboxManut"];
            Scadenze.AvvisoScadenza = Request.Form["textboxAS"];
            Scadenze.AvvisoInvioEmail = Request.Form["textboxAIE"];
            Scadenze.MittenteNome = Request.Form["textboxMN"];
            Scadenze.MittenteIndirizzo = Request.Form["textboxMI"];
            Scadenze.TestoEmail = Request.Form["textboxTE"];
            Scadenze.Ricorrente = Request.Form["textboxRR"];
            Scadenze.FormulaRinnovoScadenza = Request.Form["textboxFRS"];

            string CTS = Request.Query["CodiceTipologiaScadenza"];
            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS; Database=Scadenziario; Trusted_connection=true";
            string strSql = "UPDATE Scadenze SET DescrizioneTipologia=@DescrizioneTipologia,TipoAnagrafica=@TipoAnagrafica,Gruppo=@Gruppo,Anagrafica=@Anagrafica,ManutenzioneMacchina=@ManutenzioneMacchina,AvvisoScadenza=@AvvisoScadenza,AvvisoInvioEmail=@AvvisoInvioEmail,MittenteNome=@MittenteNome,MittenteIndirizzo=@MittenteIndirizzo,TestoEmail=@TestoEmail,Ricorrente=@Ricorrente,FormulaRinnovoScadenza=@FormulaRinnovoScadenza WHERE CodiceTipologiaScadenza=@CodiceTipologiaScadenza";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSql;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("CodiceTipologiaScadenza", CTS);
            cmd.Parameters.AddWithValue("DescrizioneTipologia", Scadenze.DescrizioneTipologia);
            cmd.Parameters.AddWithValue("TipoAnagrafica", Scadenze.TipoAnagrafica);
            cmd.Parameters.AddWithValue("Gruppo", Scadenze.Gruppo);
            cmd.Parameters.AddWithValue("Anagrafica", Scadenze.Anagrafica);
            cmd.Parameters.AddWithValue("ManutenzioneMacchina", Scadenze.ManutenzioneMacchina);
            cmd.Parameters.AddWithValue("AvvisoScadenza", Scadenze.AvvisoScadenza);
            cmd.Parameters.AddWithValue("AvvisoInvioEmail", Scadenze.AvvisoInvioEmail);
            cmd.Parameters.AddWithValue("MittenteNome", Scadenze.MittenteNome);
            cmd.Parameters.AddWithValue("MittenteIndirizzo", Scadenze.MittenteIndirizzo);
            cmd.Parameters.AddWithValue("TestoEmail", Scadenze.TestoEmail);
            cmd.Parameters.AddWithValue("Ricorrente", Scadenze.Ricorrente);
            cmd.Parameters.AddWithValue("FormulaRinnovoScadenza", Scadenze.FormulaRinnovoScadenza);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            Response.Redirect("/Tipologie/Index");
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
