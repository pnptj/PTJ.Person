using System;
using System.Collections.Generic;
using System.Linq;
using PTJ;
using PTJ.Base;
using PTJ.Person;
using PTJ.ServiceLayer;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace PTJ.Person.ServiceLayer
{
    /// <summary>
    /// Summary description for LegecyTerm
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PersonService : Base<int,                                //Key Id DataType      (I)
                                        BusinessRules.PersonHanterare,    //BusinessRules Handle (O)
                                        BusinessRules.AdressHanterare,    //BusinessRules Handle1(O1) 
                                        Nothing,                        //BusinessRules Handle2(O2) 
                                        Nothing,                        //BusinessRules Handle3(O3) 
                                        Nothing,                        //BusinessRules Handle4(O4) 
                                        Nothing,                        //BusinessRules Handle5(O5) 
                                        Nothing,                        //BusinessRules Handle6(O6) 
                                        Nothing,                        //BusinessRules Handle7(O7) 
                                        Nothing,                        //BusinessRules Handle8(O8) 
                                        Person.Schemas.PersonSchema,      //BusinessRules Handle6(T) 
                                        Person.DataLayer.Person,          //This Data Class      (D)
                                        Person.Schemas.AdressSchema,    //Referencing Schema Class 1 (VO)
                                        Nothing,                        //Referencing Schema Class 2 (WO)
                                        Nothing,                        //Referencing Schema Class 3 (XO)
                                        Nothing,                        //Referencing Schema Class 4 (YO)
                                        Nothing,                        //Referencing Schema Class 5 (ZO)
                                        Nothing,                        //Referencing Schema Class 6 (ÅO)
                                        Nothing,                        //Referencing Schema Class 7 (ÄO)
                                        Nothing,                        //Referencing Schema Class 8 (ÖO)
                                        Person.DataLayer.Adress,        //Referencing Data Class 1 (VD)
                                        Nothing,                        //Referencing Data Class 2 (WD)
                                        Nothing,                        //Referencing Data Class 3 (XD)
                                        Nothing,                        //Referencing Data Class 4 (YD)
                                        Nothing,                        //Referencing Data Class 5 (ZD)
                                        Nothing,                        //Referencing Data Class 6 (ÅD)
                                        Nothing,                        //Referencing Data Class 7 (ÄD)
                                        Nothing>                        //Referencing Data Class 8 (ÖD)
    {
        public PersonService()
        {
            initiate();
        }

        protected override void initiate()
        {
            base.initiate();
            base.lstTransportation = new Base.Schemas.TransportMessage<Person.Schemas.PersonSchema[]>();
            base.transportation = new Base.Schemas.TransportMessage<Person.Schemas.PersonSchema>();
            base.lstTransportation1 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.PersonSchema, Person.Schemas.AdressSchema>[]>();
        }

        protected override void setInitiateObjects()
        {
            base.obj = new BusinessRules.PersonHanterare();
            base.setInitiateObjects();
        }

        protected override void setTimeViewOnObjects(DateTime timeView)
        {
            base.obj.TimeView = timeView;
        }

        protected override List<Base.MessageChannel.Message> Messages(Exception ex)
        {
            return new List<Base.MessageChannel.Message>() { new Base.MessageChannel.Message() { EventTime = DateTime.Now, ExceptionMessage = ex.Message, msgType = Base.MessageChannel.Message.MessageType.Abbend, Ordinal = 0 } };
        }

        [WebMethod(MessageName = "All")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.PersonSchema[]> GetAll()
        {
            return base.getAll();
        }

        protected override Person.Schemas.PersonSchema[] All()
        {
            return obj.GetAll().Select(s => Cast(s)).ToArray(); ;
        }

        [WebMethod(MessageName = "ById")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.PersonSchema> GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.Schemas.PersonSchema ById(int id)
        {
            return Cast(obj.GetById(id));
        }

        [WebMethod(MessageName = "GetByAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.PersonSchema, Person.Schemas.AdressSchema>[]> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.PersonSchema, Person.Schemas.AdressSchema>[] ByObject1(object itemId)
        {
            return obj.GetByAdress(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.PersonSchema, Person.Schemas.AdressSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "GetByName")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.PersonSchema[]> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override Person.Schemas.PersonSchema[] By1(object variable)
        {
            return obj.GetByName(variable.ToString()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "AddPerson")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.PersonSchema[]> AddPerson(Person.Schemas.PersonSchema[] lstItems)
        {
            return base.add(lstItems);
        }

        protected override Person.Schemas.PersonSchema[] addItems(Person.Schemas.PersonSchema[] items)
        {
            return obj.Add(items.Select(s => Cast(s)).ToList()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "ChangePerson")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.PersonSchema[]> ChangePerson(Person.Schemas.PersonSchema[] lstItems)
        {
            return base.change(lstItems);
        }

        protected override Person.Schemas.PersonSchema[] changeItems(Person.Schemas.PersonSchema[] items)
        {
            return obj.Change(items.Select(s => Cast(s)).ToList()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "RemovePerson")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.PersonSchema[]> RemovePerson(Person.Schemas.PersonSchema[] lstItems)
        {
            return base.remove(lstItems);
        }

        protected override Person.Schemas.PersonSchema[] removeItems(Person.Schemas.PersonSchema[] items)
        {
            return obj.Remove(items.Select(s => Cast(s)).ToList()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "GetCurrentTimeView")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public DateTime GetCurrentTimeView()
        {
            return base.TimeView;
        }

        [WebMethod(MessageName = "SetCurrentTimeView")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public void SetCurrentTimeView(DateTime dt)
        {
            base.obj.TimeView = dt;
            base.TimeView = dt;
        }

        protected override void setMessageChannel()
        {
            obj.MsgChannel = base.msgChannel;
        }

        public override List<Base.MessageChannel.Message> getObjectMessages()
        {
            return obj.MsgChannel.Get();
        }

        protected override Person.Schemas.PersonSchema Cast(Person.DataLayer.Person dataItem)
        {
            return new Person.Schemas.PersonSchema()
            {
                Id = dataItem.Id,
                FörNamn = dataItem.FörNamn,
                MellanNamn = dataItem.MellanNamn,
                Efternamn = dataItem.Efternamn,
                PersonNummer = dataItem.PersonNummer,
                SkapadDatum = dataItem.SkapadDatum,
                UpdateradDatum = dataItem.UpdateradDatum != null ? dataItem.UpdateradDatum.Value : DateTime.MinValue,
            };
        }

        protected override Person.DataLayer.Person Cast(Person.Schemas.PersonSchema schemaItem)
        {
            return new Person.DataLayer.Person()
            {
                Id = schemaItem.Id,
                FörNamn = schemaItem.FörNamn,
                MellanNamn = schemaItem.MellanNamn,
                Efternamn = schemaItem.Efternamn,
                PersonNummer = schemaItem.PersonNummer,
                SkapadDatum = schemaItem.SkapadDatum,
                UpdateradDatum = schemaItem.UpdateradDatum,
            };
        }

        protected override Person.Schemas.AdressSchema Cast(Person.DataLayer.Adress dataItem)
        {
            return new Person.Schemas.AdressSchema()
            {
                Id = dataItem.Id,
                AdressTyp_FKID = dataItem.AdressTyp_FKID,
                Person_FKID = dataItem.Person_FKID == null ? -1 : dataItem.Person_FKID.Value,
                Organisation_FKID = dataItem.Organisation_FKID == null ? -1 : dataItem.Organisation_FKID.Value,
                AdressVariant_FKID = dataItem.AdressVariant_FKID,
                SkapadDatum = dataItem.SkapadDatum,
                UpdateradDatum = dataItem.UpdateradDatum.Value,
            };
        }

        protected override Person.DataLayer.Adress Cast(Person.Schemas.AdressSchema schemaItem)
        {
            return new Person.DataLayer.Adress()
            {
                Id = schemaItem.Id,
                AdressTyp_FKID = schemaItem.AdressTyp_FKID,
                Person_FKID = schemaItem.Person_FKID,
                Organisation_FKID = schemaItem.Organisation_FKID,
                AdressVariant_FKID = schemaItem.AdressVariant_FKID,
                SkapadDatum = schemaItem.SkapadDatum,
                UpdateradDatum = schemaItem.UpdateradDatum,
            };
        }
    }
}
