using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using static Scadenziario_MCG.Pages.Tipologie.IndexModel;

namespace Scadenziario_MCG.Pages.Tipologie
{
    public class InsertModel : PageModel
    {
        public ListaScadenze Scadenzes = new ListaScadenze();
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            Scadenzes.CodiceTipologiaScadenza = Request.Form["textboxCTS"];
            Scadenzes.DescrizioneTipologia = Request.Form["textboxDT"];
            Scadenzes.TipoAnagrafica = Request.Form["textboxTAna"];
            Scadenzes.Gruppo = Request.Form["textboxGruppo"];
            Scadenzes.Anagrafica = Request.Form["textboxAna"];
            Scadenzes.ManutenzioneMacchina = Request.Form["textboxManut"];
            Scadenzes.AvvisoScadenza = Request.Form["textboxAS"];
            Scadenzes.AvvisoInvioEmail = Request.Form["textboxAIE"];
            Scadenzes.MittenteNome = Request.Form["textboxMN"];
            Scadenzes.MittenteIndirizzo = Request.Form["textboxMI"];
            Scadenzes.TestoEmail = Request.Form["textboxTE"];
            Scadenzes.Ricorrente = Request.Form["textboxRR"];
            Scadenzes.FormulaRinnovoScadenza = Request.Form["textboxFRS"];

            string connessione = "Server=DESKTOP-UOEE9EA\\SQLEXPRESS; Database=Scadenziario; Trusted_connection=true";
            string strSql = "INSERT INTO Scadenze (CodiceTipologiaScadenza,DescrizioneTipologia,TipoAnagrafica,Gruppo,Anagrafica,ManutenzioneMacchina,AvvisoScadenza,AvvisoInvioEmail,MittenteNome,MittenteIndirizzo,TestoEmail,Ricorrente,FormulaRinnovoScadenza) VALUES (@CodiceTipologiaScadenza,@DescrizioneTipologia,@TipoAnagrafica,@Gruppo,@Anagrafica,@ManutenzioneMacchina,@AvvisoScadenza,@AvvisoInvioEmail,@MittenteNome,@MittenteIndirizzo,@TestoEmail,@Ricorrente,@FormulaRinnovoScadenza)";
            SqlConnection conn = new SqlConnection(connessione);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql,conn);
            cmd.CommandText = strSql;
            cmd.Parameters.AddWithValue("CodiceTipologiaScadenza", Scadenzes.CodiceTipologiaScadenza);
            cmd.Parameters.AddWithValue("DescrizioneTipologia", Scadenzes.DescrizioneTipologia);
            cmd.Parameters.AddWithValue("TipoAnagrafica", Scadenzes.TipoAnagrafica);
            cmd.Parameters.AddWithValue("Gruppo", Scadenzes.Gruppo);
            cmd.Parameters.AddWithValue("Anagrafica", Scadenzes.Anagrafica);
            cmd.Parameters.AddWithValue("ManutenzioneMacchina", Scadenzes.ManutenzioneMacchina);
            cmd.Parameters.AddWithValue("AvvisoScadenza", Scadenzes.AvvisoScadenza);
            cmd.Parameters.AddWithValue("AvvisoInvioEmail", Scadenzes.AvvisoInvioEmail);
            cmd.Parameters.AddWithValue("MittenteNome", Scadenzes.MittenteNome);
            cmd.Parameters.AddWithValue("MittenteIndirizzo", Scadenzes.MittenteIndirizzo);
            cmd.Parameters.AddWithValue("TestoEmail", Scadenzes.TestoEmail);
            cmd.Parameters.AddWithValue("Ricorrente", Scadenzes.Ricorrente);
            cmd.Parameters.AddWithValue("FormulaRinnovoScadenza", Scadenzes.FormulaRinnovoScadenza);
            cmd.Connection = conn;
            //ERRORE CON MANUTENZIONE MACCHINA, VALORE SCALARE DA DICHIARARE, CHIEDERE A MASSIMILIANO
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("/Tipologie/Index");
        }
    }
}
