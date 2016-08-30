using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebServiceFacadeHelper
/// </summary>
public class WebServiceFacadeHelper
{
	public WebServiceFacadeHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public PersonService.PersonService GetPersonService()
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

    public AdressTypService.AdressTypService GetAdressTypService()
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

    public AdressVariantService.AdressVariantService GetAdressVariantService()
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

    public GatuAdressService.GatuAdressService GetGatuAdressService()
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

    public MailService.MailService GetMailService()
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

    public TelefonService.TelefonService GetTelefonService()
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

    public AdressService.AdressService GetAdressService()
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

    public PersonService.TransportMessageOfArrayOfKeyValueOfPersonSchemaAdressSchema GetTransportArrPerson_Adress()
    {
        return new PersonService.TransportMessageOfArrayOfKeyValueOfPersonSchemaAdressSchema();
    }

    public PersonService.TransportMessageOfArrayOfPersonSchema GetTransportArrPerson()
    {
        return new PersonService.TransportMessageOfArrayOfPersonSchema();
    }

    public PersonService.TransportMessageOfPersonSchema GetTransportPerson()
    {
        return new PersonService.TransportMessageOfPersonSchema();
    }

    public AdressService.TransportMessageOfAdressSchema GetTransportAdress()
    {
        return new AdressService.TransportMessageOfAdressSchema();
    }

    public AdressService.TransportMessageOfArrayOfAdressSchema GetTransportArrAdress()
    {
        return new AdressService.TransportMessageOfArrayOfAdressSchema();
    }

    public AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressTypSchema GetTransportArrAdress_AdressTyp()
    {
        return new AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressTypSchema();
    }

    public AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressVariantSchema GetTransportArrAdress_AdressVariant()
    {
        return new AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressVariantSchema();
    }

    public AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaGatuAdressSchema GetTransportArrAdress_GatuAdress()
    {
        return new AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaGatuAdressSchema();
    }

    public AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaMailSchema GetTransportArrAdress_Mail()
    {
        return new AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaMailSchema();
    }

    public AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaPersonSchema GetTransportArrAdress_Person()
    {
        return new AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaPersonSchema();
    }

    public AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaTelefonSchema GetTransportArrAdress_Telefon()
    {
        return new AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaTelefonSchema();
    }

    public AdressVariantService.TransportMessageOfAdressVariantSchema GetTransportAdressVariant()
    {
        return new AdressVariantService.TransportMessageOfAdressVariantSchema();
    }

    public AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema GetTransportArrAdressVariant()
    {
        return new AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema();
    }

    public AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressSchema GetTransportArrAdressVariant_Adress()
    {
        return new AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressSchema();
    }

    public AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressTypSchema GetTransportArrAdressVariant_AdressTyp()
    {
        return new AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressTypSchema();
    }

    public GatuAdressService.TransportMessageOfArrayOfGatuAdressSchema GetTransportArrGatuAdress()
    {
        return new GatuAdressService.TransportMessageOfArrayOfGatuAdressSchema();
    }

    public GatuAdressService.TransportMessageOfArrayOfKeyValueOfGatuAdressSchemaAdressSchema GetTransportArrGatuAdress_Adress()
    {
        return new GatuAdressService.TransportMessageOfArrayOfKeyValueOfGatuAdressSchemaAdressSchema();
    }

    public GatuAdressService.TransportMessageOfGatuAdressSchema GetTransportGatuAdress()
    {
        return new GatuAdressService.TransportMessageOfGatuAdressSchema();
    }

    public MailService.TransportMessageOfMailSchema GetTransportMail()
    {
        return new MailService.TransportMessageOfMailSchema();
    }

    public MailService.TransportMessageOfArrayOfMailSchema GetTransportArrMail()
    {
        return new MailService.TransportMessageOfArrayOfMailSchema();
    }

    public MailService.TransportMessageOfArrayOfKeyValueOfMailSchemaAdressSchema GetTransportArrMail_Adress()
    {
        return new MailService.TransportMessageOfArrayOfKeyValueOfMailSchemaAdressSchema();
    }

    public TelefonService.TransportMessageOfTelefonSchema GetTransportTelefon()
    {
        return new TelefonService.TransportMessageOfTelefonSchema();
    }

    public TelefonService.TransportMessageOfArrayOfTelefonSchema GetTransportArrTelefon()
    {
        return new TelefonService.TransportMessageOfArrayOfTelefonSchema();
    }

    public TelefonService.TransportMessageOfArrayOfKeyValueOfTelefonSchemaAdressSchema GetTransportArrTelefon_Adress()
    {
        return new TelefonService.TransportMessageOfArrayOfKeyValueOfTelefonSchemaAdressSchema();
    }

    public bool HasMessages(PersonService.TransportMessageOfArrayOfKeyValueOfPersonSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(PersonService.TransportMessageOfArrayOfPersonSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(PersonService.TransportMessageOfPersonSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(AdressService.TransportMessageOfAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(AdressService.TransportMessageOfArrayOfAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressTypSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressVariantSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaGatuAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaMailSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaPersonSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaTelefonSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(AdressVariantService.TransportMessageOfAdressVariantSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressTypSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(GatuAdressService.TransportMessageOfArrayOfGatuAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }
   
    public bool HasMessages(GatuAdressService.TransportMessageOfArrayOfKeyValueOfGatuAdressSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(GatuAdressService.TransportMessageOfGatuAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(MailService.TransportMessageOfMailSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(MailService.TransportMessageOfArrayOfMailSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(MailService.TransportMessageOfArrayOfKeyValueOfMailSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(TelefonService.TransportMessageOfTelefonSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(TelefonService.TransportMessageOfArrayOfTelefonSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public bool HasMessages(TelefonService.TransportMessageOfArrayOfKeyValueOfTelefonSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.Count() > 0;
    }

    public List<PersonService.Message> GetMessages(PersonService.TransportMessageOfArrayOfKeyValueOfPersonSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<PersonService.Message> GetMessages(PersonService.TransportMessageOfArrayOfPersonSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<PersonService.Message> GetMessages(PersonService.TransportMessageOfPersonSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressTypSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressVariantSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaGatuAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaMailSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaPersonSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressService.Message> GetMessages(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaTelefonSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressVariantService.Message> GetMessages(AdressVariantService.TransportMessageOfAdressVariantSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressVariantService.Message> GetMessages(AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressVariantService.Message> GetMessages(AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<AdressVariantService.Message> GetMessages(AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressTypSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<GatuAdressService.Message> GetMessages(GatuAdressService.TransportMessageOfArrayOfGatuAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<GatuAdressService.Message> GetMessages(GatuAdressService.TransportMessageOfArrayOfKeyValueOfGatuAdressSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<GatuAdressService.Message> GetMessages(GatuAdressService.TransportMessageOfGatuAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<MailService.Message> GetMessages(MailService.TransportMessageOfMailSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<MailService.Message> GetMessages(MailService.TransportMessageOfArrayOfMailSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<MailService.Message> GetMessages(MailService.TransportMessageOfArrayOfKeyValueOfMailSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<TelefonService.Message> GetMessages(TelefonService.TransportMessageOfTelefonSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<TelefonService.Message> GetMessages(TelefonService.TransportMessageOfArrayOfTelefonSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<TelefonService.Message> GetMessages(TelefonService.TransportMessageOfArrayOfKeyValueOfTelefonSchemaAdressSchema transportItem)
    {
        return transportItem.lstMessages.ToList();
    }

    public List<PersonService.KeyValueOfPersonSchemaAdressSchema> GetData(PersonService.TransportMessageOfArrayOfKeyValueOfPersonSchemaAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<PersonService.PersonSchema> GetData(PersonService.TransportMessageOfArrayOfPersonSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public PersonService.PersonSchema GetData(PersonService.TransportMessageOfPersonSchema transportItem)
    {
        return transportItem.Data;
    }

    public AdressService.AdressSchema GetData(AdressService.TransportMessageOfAdressSchema transportItem)
    {
        return transportItem.Data;
    }

    public List<AdressService.AdressSchema> GetData(AdressService.TransportMessageOfArrayOfAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressService.KeyValueOfAdressSchemaAdressTypSchema> GetData(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressTypSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressService.KeyValueOfAdressSchemaAdressVariantSchema> GetData(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaAdressVariantSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressService.KeyValueOfAdressSchemaGatuAdressSchema> GetData(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaGatuAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressService.KeyValueOfAdressSchemaMailSchema> GetData(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaMailSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressService.KeyValueOfAdressSchemaPersonSchema> GetData(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaPersonSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressService.KeyValueOfAdressSchemaTelefonSchema> GetData(AdressService.TransportMessageOfArrayOfKeyValueOfAdressSchemaTelefonSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public AdressVariantService.AdressVariantSchema GetData(AdressVariantService.TransportMessageOfAdressVariantSchema transportItem)
    {
        return transportItem.Data;
    }

    public List<AdressVariantService.AdressVariantSchema> GetData(AdressVariantService.TransportMessageOfArrayOfAdressVariantSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressVariantService.KeyValueOfAdressVariantSchemaAdressSchema> GetData(AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<AdressVariantService.KeyValueOfAdressVariantSchemaAdressTypSchema> GetData(AdressVariantService.TransportMessageOfArrayOfKeyValueOfAdressVariantSchemaAdressTypSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<GatuAdressService.GatuAdressSchema> GetData(GatuAdressService.TransportMessageOfArrayOfGatuAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<GatuAdressService.KeyValueOfGatuAdressSchemaAdressSchema> GetData(GatuAdressService.TransportMessageOfArrayOfKeyValueOfGatuAdressSchemaAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public GatuAdressService.GatuAdressSchema GetData(GatuAdressService.TransportMessageOfGatuAdressSchema transportItem)
    {
        return transportItem.Data;
    }

    public MailService.MailSchema GetData(MailService.TransportMessageOfMailSchema transportItem)
    {
        return transportItem.Data;
    }

    public List<MailService.MailSchema> GetData(MailService.TransportMessageOfArrayOfMailSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<MailService.KeyValueOfMailSchemaAdressSchema> GetData(MailService.TransportMessageOfArrayOfKeyValueOfMailSchemaAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public TelefonService.TelefonSchema GetData(TelefonService.TransportMessageOfTelefonSchema transportItem)
    {
        return transportItem.Data;
    }

    public List<TelefonService.TelefonSchema> GetData(TelefonService.TransportMessageOfArrayOfTelefonSchema transportItem)
    {
        return transportItem.Data.ToList();
    }

    public List<TelefonService.KeyValueOfTelefonSchemaAdressSchema> GetData(TelefonService.TransportMessageOfArrayOfKeyValueOfTelefonSchemaAdressSchema transportItem)
    {
        return transportItem.Data.ToList();
    }
}