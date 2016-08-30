using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private WebServiceFacadeHelper wbHlp = null;

    public _Default()
    {
        wbHlp = new WebServiceFacadeHelper();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        else
        {

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtSearchPerson.Text.Trim() != "")
        {
            var trpPerson = wbHlp.GetPersonService().GetByName(txtSearchPerson.Text);
            if (!wbHlp.HasMessages(trpPerson))
            {
                gvPersoner.DataSource = wbHlp.GetData(trpPerson);
                gvPersoner.DataBind();
            }
        }
    }
    protected void gvPersoner_SelectedIndexChanged(object sender, EventArgs e)
    {
        int personId = Convert.ToInt32(gvPersoner.SelectedRow.Cells[1].Text);
        var trpAdress = wbHlp.GetAdressService().GetByPerson(personId);
        if (!wbHlp.HasMessages(trpAdress))
        {
            var lstAdresser = wbHlp.GetData(trpAdress).Select(s => s.Key).Distinct().ToList();
            var trpAdressVarianter = wbHlp.GetAdressVariantService().GetAll();
            if (!wbHlp.HasMessages(trpAdressVarianter))
            {
                var lstAdressVarianter = wbHlp.GetData(trpAdressVarianter);
                List<GatuAdressService.GatuAdressSchema> lstGatuadresser = new List<GatuAdressService.GatuAdressSchema>();
                List<MailService.MailSchema> lstMailAdresser = new List<MailService.MailSchema>();
                List<TelefonService.TelefonSchema> lstTelefonNummer = new List<TelefonService.TelefonSchema>();

                foreach (AdressService.AdressSchema adress in lstAdresser)
                {
                    var trpGatuadress = wbHlp.GetGatuAdressService().GetByAdress(adress.Id);
                    if (!wbHlp.HasMessages(trpGatuadress))
                    {
                        lstGatuadresser.AddRange(wbHlp.GetData(trpGatuadress).Select(s => s.Key).Distinct().ToList());
                    }
                    var trpMailadress = wbHlp.GetMailService().GetByAdress(adress.Id);
                    if (!wbHlp.HasMessages(trpMailadress))
                    {
                        lstMailAdresser.AddRange(wbHlp.GetData(trpMailadress).Select(s => s.Key).Distinct().ToList());
                    }
                    var trpTelefon = wbHlp.GetTelefonService().GetByAdress(adress.Id);
                    if (!wbHlp.HasMessages(trpTelefon))
                    {
                        lstTelefonNummer.AddRange(wbHlp.GetData(trpTelefon).Select(s => s.Key).Distinct().ToList());
                    }
                }
                gvGatuAdresser.DataSource = (from a in lstGatuadresser
                                              join b in lstAdressVarianter on a.AdressVariant_FKID equals b.Id
                                              select new {Key = a, Value = b});
                gvTelefonNummer.DataSource = (from a in lstTelefonNummer
                                              join b in lstAdressVarianter on a.AdressVariant_FKID equals b.Id
                                              select new {Key = a, Value = b});
                gvMailAdresser.DataSource = (from a in lstMailAdresser
                                              join b in lstAdressVarianter on a.AdressVariant_FKID equals b.Id
                                              select new {Key = a, Value = b});

                gvGatuAdresser.DataBind();
                gvTelefonNummer.DataBind();
                gvMailAdresser.DataBind();
            }
        }
    }
}