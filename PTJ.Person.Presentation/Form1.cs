using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTJ.Person.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<AdressTypService.AdressTypSchema> lstAdressTyper = null;
        private List<AdressVariantService.AdressVariantSchema> lstAdressVarianter = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            //AddAdressTyper();
            //AddAdressVarianter();
            //Add1000Persons();

            AdressTypService.TransportMessageOfArrayOfAdressTypSchema trpAdressTyper = getAdressTypService().GetAll();
            if (trpAdressTyper.lstMessages.Count() == 0) { lstAdressTyper = trpAdressTyper.Data.ToList(); }
            AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema trpAdressVariants = getAdressVariantService().GetAll();
            if (trpAdressVariants.lstMessages.Count() == 0) { lstAdressVarianter = trpAdressVariants.Data.ToList(); }
            //AddRandomPersonAndAdress();
        }

        private void AddRandomPersonAndAdress()
        {
            //PersonService.TransportMessageOfArrayOfPersonSchema trpPerson = Add1000Persons();

            PersonService.TransportMessageOfArrayOfPersonSchema trpPerson = getPersonService().GetAll();

            if (trpPerson.lstMessages.Count() == 0)
            {
                List<PersonService.PersonSchema> lstPerson = trpPerson.Data.ToList();
                Random rndAdressTypes = new Random(1); Random rndAdressVariants = new Random(1);

                List<AdressService.AdressSchema> lstAdressSchema = new List<AdressService.AdressSchema>();
                List<GatuAdressService.GatuAdressSchema> lstGatuAdressSchema = new List<GatuAdressService.GatuAdressSchema>();
                List<MailService.MailSchema> lstMailSchema = new List<MailService.MailSchema>();
                List<TelefonService.TelefonSchema> lstTelefonSchema = new List<TelefonService.TelefonSchema>();
                
                foreach (PersonService.PersonSchema person in lstPerson)
                {
                    int nbrOfAdressTypes = lstAdressTyper.Count();

                    List<AdressTypService.AdressTypSchema> lstAdressTypesForPerson = new List<AdressTypService.AdressTypSchema>();
                    List<AdressVariantService.AdressVariantSchema> lstAdressVariantForPerson = new List<AdressVariantService.AdressVariantSchema>();

                    int nbrOfAdressTypesForPerson = rndAdressTypes.Next(1, nbrOfAdressTypes);

                    for (int adressTypesCounter = 0; adressTypesCounter <= nbrOfAdressTypesForPerson; adressTypesCounter++)
                    {
                        AdressTypService.AdressTypSchema adressType = lstAdressTyper.Except(lstAdressTypesForPerson).ElementAt(rndAdressTypes.Next(0, lstAdressTyper.Except(lstAdressTypesForPerson).Count()));
                        lstAdressTypesForPerson.Add(adressType);
                        List<AdressVariantService.AdressVariantSchema> lstVariantsOnType = lstAdressVarianter.Where(w => w.AdressTyp_FKID == adressType.Id).Distinct().ToList();

                        int nbrOfAdressVariantsForPerson = rndAdressVariants.Next(1, lstVariantsOnType.Count());

                        for (int adressVariantsCounter = 0; adressVariantsCounter <= nbrOfAdressVariantsForPerson; adressVariantsCounter++)
                        {
                            AdressVariantService.AdressVariantSchema adressVariant = lstVariantsOnType.Except(lstAdressVariantForPerson).ElementAt(rndAdressVariants.Next(0, lstVariantsOnType.Except(lstAdressVariantForPerson).Count()));
                            lstAdressVariantForPerson.Add(adressVariant);

                            lstAdressSchema.Add(
                                new AdressService.AdressSchema()
                                {
                                    AdressTyp_FKID = adressType.Id,
                                    AdressVariant_FKID = adressVariant.Id,
                                    Organisation_FKID = -1,
                                    Person_FKID = person.Id,
                                });
                        }
                    }
                    AdressService.TransportMessageOfArrayOfAdressSchema trpArrayOfAdressSchema = getAdressService().AddAdress(lstAdressSchema.ToArray());
                    lstAdressSchema = new List<AdressService.AdressSchema>();
                    if (trpArrayOfAdressSchema.lstMessages.Count() != 0)
                    {
                        throw new Exception("Wrong!!!");
                    }
                }

                AdressService.TransportMessageOfArrayOfAdressSchema trpArrayOfAllAdressSchema = getAdressService().GetAll();

                if (trpArrayOfAllAdressSchema.lstMessages.Count() == 0)
                {
                    lstAdressSchema = trpArrayOfAllAdressSchema.Data.ToList();

                    foreach (AdressService.AdressSchema adressSchema in lstAdressSchema)
                    {
                        try
                        {
                            AdressTypService.AdressTypSchema adressTypOnAdress = lstAdressTyper.Where(w => w.Id == adressSchema.AdressTyp_FKID).First();
                            AdressVariantService.AdressVariantSchema adressVarOnAdress = lstAdressVarianter.Where(w => w.Id == adressSchema.AdressVariant_FKID).First();
                            if (adressTypOnAdress.Id == 1 && adressVarOnAdress.Id >= 1 && adressVarOnAdress.Id <= 6)
                            {
                                lstGatuAdressSchema.Add(getGatuAdress(lstPerson.Where(w => w.Id == adressSchema.Person_FKID).First(), adressSchema.Id, adressTypOnAdress.Id, adressVarOnAdress.Id));
                            }
                            if (adressTypOnAdress.Id == 2 && adressVarOnAdress.Id >= 7 && adressVarOnAdress.Id <= 8)
                            {
                                lstMailSchema.Add(getMail(lstPerson.Where(w => w.Id == adressSchema.Person_FKID).First(), adressSchema.Id, adressTypOnAdress.Id, adressVarOnAdress.Id));
                            }
                            if (adressTypOnAdress.Id == 3 && adressVarOnAdress.Id >= 9 && adressVarOnAdress.Id <= 12)
                            {
                                lstTelefonSchema.Add(getTelefon(lstPerson.Where(w => w.Id == adressSchema.Person_FKID).First(), adressSchema.Id, adressTypOnAdress.Id, adressVarOnAdress.Id));
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    GatuAdressService.TransportMessageOfArrayOfGatuAdressSchema trpGatuAdress = getGatuAdressService().AddGatuAdress(lstGatuAdressSchema.ToArray());
                    if (trpGatuAdress.lstMessages.Count() == 0)
                    {
                        MailService.TransportMessageOfArrayOfMailSchema trpMail = getMailService().AddMailAdress(lstMailSchema.ToArray());
                        if (trpMail.lstMessages.Count() == 0)
                        {
                            TelefonService.TransportMessageOfArrayOfTelefonSchema trpTelefon = getTelefonService().AddTelefon(lstTelefonSchema.ToArray());
                            if (trpTelefon.lstMessages.Count() == 0)
                            {

                            }
                        }
                    }
                }
            }
        }

        private GatuAdressService.GatuAdressSchema getGatuAdress(PersonService.PersonSchema person, int adressId, int adressTyp, int adressVariant)
        {
            string nbrsEnding = person.Efternamn.Replace("Efternamn", "");
            string adressTypeString = "Folkbokföringsadress";
            if (adressVariant == 1) { adressTypeString = "Folkbokföringsadress"; }
            if (adressVariant == 2) { adressTypeString = "Adress Arbete"; }
            if (adressVariant == 3) { adressTypeString = "LeveransAdress"; }
            if (adressVariant == 4) { adressTypeString = "FaktureringsAdress"; }
            if (adressVariant == 5) { adressTypeString = "Adressens Adress"; }
            if (adressVariant == 6) { adressTypeString = "Tomte Adress"; }

            return new GatuAdressService.GatuAdressSchema()
            {
                Adress_FKID = adressId,
                AdressTyp_FKID = adressTyp,
                AdressVariant_FKID = adressVariant,
                AdressRad1 = "AdressRad1" + adressTypeString + nbrsEnding,
                AdressRad2 = "AdressRad2" + adressTypeString + nbrsEnding,
                AdressRad3 = "AdressRad3" + adressTypeString + nbrsEnding,
                AdressRad4 = "AdressRad4" + adressTypeString + nbrsEnding,
                AdressRad5 = "AdressRad5" + adressTypeString + nbrsEnding,
                Postnummer = Convert.ToInt32(nbrsEnding + nbrsEnding + nbrsEnding),
                Stad = "Stad" + nbrsEnding,
                Land = "Land" + nbrsEnding,
            };
        }

        private MailService.MailSchema getMail(PersonService.PersonSchema person, int adressId, int adressTyp, int adressVariant)
        {
            string mailDomainString = adressVariant == 7 ? "@ptj.se" : "@gmail.com";
            string nbrsEnding = person.Efternamn.Replace("Efternamn", "");
            return new MailService.MailSchema()
            {
                Adress_FKID = adressId,
                AdressTyp_FKID = adressTyp,
                AdressVariant_FKID = adressVariant,
                MailAdress = person.FörNamn + "." + person.Efternamn + mailDomainString,
            };
        }

        private TelefonService.TelefonSchema getTelefon(PersonService.PersonSchema person, int adressId, int adressTyp, int adressVariant)
        {
            string areaCode = "08";
            if (adressVariant >= 9 && adressVariant <= 10) { areaCode = "070"; }
            string nbrsEnding = person.Efternamn.Replace("Efternamn", "");
            return new TelefonService.TelefonSchema()
            {
                Adress_FKID = adressId,
                AdressTyp_FKID = adressTyp,
                AdressVariant_FKID = adressVariant,
                TelefonNummer = Convert.ToInt32(areaCode + nbrsEnding + nbrsEnding),
            };
        }

        private static PersonService.PersonService getPersonService()
        {
            PersonService.PersonService personService = new PersonService.PersonService();
            personService.PTJSoapHeaderValue = new PersonService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return personService;
        }

        private static AdressTypService.AdressTypService getAdressTypService()
        {
            AdressTypService.AdressTypService adressTypService = new AdressTypService.AdressTypService();
            adressTypService.PTJSoapHeaderValue = new AdressTypService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return adressTypService;
        }

        private static AdressVariantService.AdressVariantService getAdressVariantService()
        {
            AdressVariantService.AdressVariantService adressVariantService = new AdressVariantService.AdressVariantService();
            adressVariantService.PTJSoapHeaderValue = new AdressVariantService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return adressVariantService;
        }

        private static GatuAdressService.GatuAdressService getGatuAdressService()
        {
            GatuAdressService.GatuAdressService gatuAdressService = new GatuAdressService.GatuAdressService();
            gatuAdressService.PTJSoapHeaderValue = new GatuAdressService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return gatuAdressService;
        }

        private static MailService.MailService getMailService()
        {
            MailService.MailService mailService = new MailService.MailService();
            mailService.PTJSoapHeaderValue = new MailService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return mailService;
        }

        private static TelefonService.TelefonService getTelefonService()
        {
            TelefonService.TelefonService telefonService = new TelefonService.TelefonService();
            telefonService.PTJSoapHeaderValue = new TelefonService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return telefonService;
        }

        private static AdressService.AdressService getAdressService()
        {
            AdressService.AdressService adressService = new AdressService.AdressService();
            adressService.PTJSoapHeaderValue = new AdressService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            return adressService;
        }

        private string twoDigits(int number)
        {
            if (number.ToString().Length == 1)
            {
                return "0" + number.ToString();
            }
            else
            {
                return number.ToString();
            }
        }

        private static PersonService.TransportMessageOfArrayOfPersonSchema Add1000Persons()
        {

            PersonService.PersonService personSrv = getPersonService();

            Random rndYear = new Random(1); Random rndMonth = new Random(1); Random rndDay = new Random(1); Random rndLastDigits = new Random(1);

            List<PersonService.PersonSchema> lstPersonSchema = new List<PersonService.PersonSchema>();
            for (int i = 0; i < 500; i++)
            {
                string year = rndYear.Next(1900, 2016).ToString();
                string month = rndMonth.Next(1, 12).ToString(); if (month.Length == 1) { month = "0" + month; }
                string day = rndDay.Next(1, 28).ToString(); if (day.Length == 1) { day = "0" + day; }

                lstPersonSchema.Add(new PersonService.PersonSchema() { FörNamn = "Förnamn_" + i.ToString(), MellanNamn = "MellanNamn" + i.ToString(), Efternamn = "Efternamn" + i.ToString(), PersonNummer = year + month + day + rndLastDigits.Next(1111, 9999).ToString() });
            }
            PersonService.TransportMessageOfArrayOfPersonSchema trpPerson = personSrv.AddPerson(lstPersonSchema.ToArray());

            return trpPerson;
        }

        private void AddAdressTyper()
        {
            AdressTypService.AdressTypService AdressTypSrv = new AdressTypService.AdressTypService();
            AdressTypSrv.PTJSoapHeaderValue = new AdressTypService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            List<AdressTypService.AdressTypSchema> lstAdressTyp = new List<AdressTypService.AdressTypSchema>()
            {
                new AdressTypService.AdressTypSchema()
                {
                    Typ = "GatuAdress",
                },
                new AdressTypService.AdressTypSchema()
                {
                    Typ = "MailAdress",
                },
                new AdressTypService.AdressTypSchema()
                {
                    Typ = "Telefon",
                },
            };
            AdressTypService.TransportMessageOfArrayOfAdressTypSchema trpAdressTyp = AdressTypSrv.AddAdressTyp(lstAdressTyp.ToArray());
        }

        private void AddAdressVarianter()
        {
            AdressVariantService.AdressVariantService AdressVariantSrv = new AdressVariantService.AdressVariantService();
            AdressVariantSrv.PTJSoapHeaderValue = new AdressVariantService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };

            AdressTypService.AdressTypService AdressTypSrv = new AdressTypService.AdressTypService();
            AdressTypSrv.PTJSoapHeaderValue = new AdressTypService.PTJSoapHeader()
            {
                TimeView = DateTime.Now,
                CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                CurrentRowLevelSecurity = "N/D",
                CurrentDataRole = "SomeRole",
            };
            AdressTypService.TransportMessageOfAdressTypSchema trpAdressTyp = AdressTypSrv.GetById(1);
            if (trpAdressTyp.lstMessages.Count() == 0)
            {
                AdressTypService.AdressTypSchema addressType = trpAdressTyp.Data;

                List<AdressVariantService.AdressVariantSchema> lstAdressVariantSchema = new List<AdressVariantService.AdressVariantSchema>()
                {
                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Folkbokföringsadress"},
                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Adress Arbete"},
                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "LeveransAdress"},
                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "FaktureringsAdress"},
                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Adressens Adress"},
                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Tomte Adress"},
               };

                AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema addressVariant = AdressVariantSrv.AddAdressVariant(lstAdressVariantSchema.ToArray());
                if (addressVariant.lstMessages.Count() == 0)
                {
                    trpAdressTyp = AdressTypSrv.GetById(2);
                    if (trpAdressTyp.lstMessages.Count() == 0)
                    {
                        addressType = trpAdressTyp.Data;
                        lstAdressVariantSchema = new List<AdressVariantService.AdressVariantSchema>()
                        {
                            new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "MailAdress Arbete"},
                            new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Mailadress Privat"},
                        };
                        addressVariant = AdressVariantSrv.AddAdressVariant(lstAdressVariantSchema.ToArray());
                        if (addressVariant.lstMessages.Count() == 0)
                        {
                            trpAdressTyp = AdressTypSrv.GetById(3);
                            if (trpAdressTyp.lstMessages.Count() == 0)
                            {
                                addressType = trpAdressTyp.Data;
                                lstAdressVariantSchema = new List<AdressVariantService.AdressVariantSchema>()
                                {
                                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Mobil Arbete"},
                                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Mobil Privat"},
                                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Telefon Arbete"},
                                    new AdressVariantService.AdressVariantSchema(){  AdressTyp_FKID = addressType.Id, Variant = "Telefon Privat"},
                                };
                                addressVariant = AdressVariantSrv.AddAdressVariant(lstAdressVariantSchema.ToArray());
                                if (addressVariant.lstMessages.Count() == 0)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            
            if (txtSearchPerson.Text.Trim() != "")
            {
                var trpPerson = getPersonService().GetByName(txtSearchPerson.Text);
                if (trpPerson.lstMessages.Count() == 0)
                {
                    updatetvFoundPeople(trpPerson.Data.ToList());
                }
            }
        }

        private void updatetvFoundPeople(List<PersonService.PersonSchema> lstPersoner)
        {
            tvFoundPeople.Nodes.Clear();
            foreach (PersonService.PersonSchema person in lstPersoner)
            {
                tvFoundPeople.Nodes.Add(new TreeNode(person.PersonNummer + "; " + person.Efternamn + "; " + person.MellanNamn + "; " + person.FörNamn)
                {
                    Tag = person,
                });
            }
        }

        private void tvFoundPeople_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            PersonService.PersonSchema person = ((PersonService.PersonSchema)e.Node.Tag);
            AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaPersonSchema trpAdress = getAdressService().GetByPerson(person.Id);

            if (trpAdress.lstMessages.Count() == 0)
            {
                var lstAdresser = trpAdress.Data.Select(s => s.Key).Distinct().ToList();
                List<GatuAdressService.GatuAdressSchema> lstGatuadresser = new List<GatuAdressService.GatuAdressSchema>();
                List<MailService.MailSchema> lstMailAdresser = new List<MailService.MailSchema>();
                List<TelefonService.TelefonSchema> lstTelefonNummer = new List<TelefonService.TelefonSchema>();
                foreach (AdressService.AdressSchema adress in lstAdresser)
                {
                    GatuAdressService.TransportMessageOfArrayOfKeyValueOfGatuAdressSchemaAdressSchema trpGatuadress = getGatuAdressService().GetByAdress(adress.Id);
                    MailService.TransportMessageOfArrayOfKeyValueOfMailSchemaAdressSchema trpMailadress = getMailService().GetByAdress(adress.Id);
                    TelefonService.TransportMessageOfArrayOfKeyValueOfTelefonSchemaAdressSchema trpTelefon = getTelefonService().GetByAdress(adress.Id);
                    if (trpGatuadress.lstMessages.Count() == 0) { lstGatuadresser.AddRange(trpGatuadress.Data.Select(s => s.Key).Distinct().ToList()); }
                    if (trpMailadress.lstMessages.Count() == 0) { lstMailAdresser.AddRange(trpMailadress.Data.Select(s => s.Key).Distinct().ToList()); }
                    if (trpTelefon.lstMessages.Count() == 0) { lstTelefonNummer.AddRange(trpTelefon.Data.Select(s => s.Key).Distinct().ToList()); }
                }
                updateGatuadresser(lstGatuadresser);
                updateMailadresser(lstMailAdresser);
                updateTelefon(lstTelefonNummer);
            }

        }

        private void updateGatuadresser(List<GatuAdressService.GatuAdressSchema> lstGatuadresser)
        {
            txtGatuadresser.Text = "";
            lstGatuadresser.ForEach(f=> 
                    txtGatuadresser.Text = txtGatuadresser.Text
                    + getStartings(f.Id) + Environment.NewLine
                    + "     Variant     = " + lstAdressVarianter.Where(w => w.Id == f.AdressVariant_FKID).Select(s => s.Variant).FirstOrDefault() + Environment.NewLine
                    + "     AdressRad1  = " + f.AdressRad1 + Environment.NewLine
                    + "     AdressRad2  = " + f.AdressRad2 + Environment.NewLine
                    + "     AdressRad3  = " + f.AdressRad3 + Environment.NewLine
                    + "     AdressRad4  = " + f.AdressRad4 + Environment.NewLine
                    + "     AdressRad5  = " + f.AdressRad5 + Environment.NewLine
                    + "     Postnummer  = " + f.Postnummer.ToString() + Environment.NewLine
                    + "     Stad        = " + f.Stad + Environment.NewLine
                    + "     Land        = " + f.Land + Environment.NewLine
                    + "     Datum       = " + ((f.UpdateradDatum == new DateTime(1800, 01, 01)) ? f.SkapadDatum.ToString() : f.UpdateradDatum.ToString()) + Environment.NewLine
                    + getEndings(f.Id) + Environment.NewLine
                );
        }
     
        private void updateMailadresser(List<MailService.MailSchema> lstMailadresser)
        {
            txtMailAdresser.Text = "";
            lstMailadresser.ForEach(f =>
                    txtMailAdresser.Text = txtMailAdresser.Text
                    + getStartings(f.Id) + Environment.NewLine
                    + "     Variant     = " + lstAdressVarianter.Where(w => w.Id == f.AdressVariant_FKID).Select(s => s.Variant).FirstOrDefault() + Environment.NewLine
                    + "     MailAdress  = " + f.MailAdress + Environment.NewLine
                    + "     Datum       = " + ((f.UpdateradDatum == new DateTime(1800, 01, 01)) ? f.SkapadDatum.ToString() : f.UpdateradDatum.ToString()) + Environment.NewLine
                    + getEndings(f.Id) + Environment.NewLine
                );
        }
        
        private void updateTelefon(List<TelefonService.TelefonSchema> lstTelefon)
        {
            txtTelefoneNummer.Text = "";
            lstTelefon.ForEach(f =>
                    txtTelefoneNummer.Text = txtTelefoneNummer.Text
                    + getStartings(f.Id) + Environment.NewLine
                    + "     Variant     = " + lstAdressVarianter.Where(w => w.Id == f.AdressVariant_FKID).Select(s => s.Variant).FirstOrDefault() + Environment.NewLine
                    + "     TelefonNummer   = 0" + f.TelefonNummer + Environment.NewLine
                    + "     Datum           = " + ((f.UpdateradDatum == new DateTime(1800, 01, 01)) ? f.SkapadDatum.ToString() : f.UpdateradDatum.ToString()) + Environment.NewLine
                    + getEndings(f.Id) + Environment.NewLine
               );
        }

        private string getStartings(int id)
        {
            string result = "************** Item := " + id.ToString() + "************************";
            return result;
        }

        private string getEndings(int id)
        {
            string result = "";
            foreach (var chr in getStartings(id).ToArray())
            {
                result = result + "*";
            }
            return result;
        }
    }
}