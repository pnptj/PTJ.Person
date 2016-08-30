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
    public class AdressService : Base<int,                                      //Key Id DataType      (I)
                                        BusinessRules.AdressHanterare,          //BusinessRules Handle (O)
                                        BusinessRules.AdressTypHanterare,       //BusinessRules Handle1(O1) 
                                        BusinessRules.AdressVariantHanterare,   //BusinessRules Handle2(O2) 
                                        BusinessRules.GatuAdressHanterare,      //BusinessRules Handle3(O3) 
                                        BusinessRules.MailHanterare,            //BusinessRules Handle4(O4) 
                                        BusinessRules.PersonHanterare,          //BusinessRules Handle5(O5) 
                                        BusinessRules.TelefonHanterare,         //BusinessRules Handle6(O6) 
                                        Nothing,                                //BusinessRules Handle7(O7) 
                                        Nothing,                                //BusinessRules Handle8(O8) 
                                        Person.Schemas.AdressSchema,            //This Schema Class (T) 
                                        Person.DataLayer.Adress,                //This Data Class      (D)
                                        Person.Schemas.AdressTypSchema,         //Referencing Schema Class 1 (VO)
                                        Person.Schemas.AdressVariantSchema,     //Referencing Schema Class 2 (WO)
                                        Person.Schemas.GatuAdressSchema,        //Referencing Schema Class 3 (XO)
                                        Person.Schemas.MailSchema,              //Referencing Schema Class 4 (YO)
                                        Person.Schemas.PersonSchema,            //Referencing Schema Class 5 (ZO)
                                        Person.Schemas.TelefonSchema,           //Referencing Schema Class 6 (ÅO)
                                        Nothing,                                //Referencing Schema Class 7 (ÄO)
                                        Nothing,                                //Referencing Schema Class 8 (ÖO)
                                        Person.DataLayer.AdressTyp,     //Referencing Data Class 1 (VD)
                                        Person.DataLayer.AdressVariant, //Referencing Data Class 2 (WD)
                                        Person.DataLayer.GatuAdress,    //Referencing Data Class 3 (XD)
                                        Person.DataLayer.Mail,          //Referencing Data Class 4 (YD)
                                        Person.DataLayer.Person,        //Referencing Data Class 5 (ZD)
                                        Person.DataLayer.Telefon,       //Referencing Data Class 6 (ÅD)
                                        Nothing,                        //Referencing Data Class 7 (ÄD)
                                        Nothing>                        //Referencing Data Class 8 (ÖD)
    {
        public AdressService()
        {
            initiate();
        }

        protected override void initiate()
        {
            base.initiate();
            base.lstTransportation = new Base.Schemas.TransportMessage<Person.Schemas.AdressSchema[]>();
            base.transportation = new Base.Schemas.TransportMessage<Person.Schemas.AdressSchema>();
            base.lstTransportation1 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[]>();
            base.lstTransportation2 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[]>();
            base.lstTransportation3 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[]>();
            base.lstTransportation4 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[]>();
            base.lstTransportation5 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.PersonSchema>[]>();
            base.lstTransportation6 = new Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[]>();
        }

        protected override void setInitiateObjects()
        {
            base.obj = new BusinessRules.AdressHanterare();
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
        public Base.Schemas.TransportMessage<Person.Schemas.AdressSchema[]> GetAll()
        {
            return base.getAll();
        }

        protected override Person.Schemas.AdressSchema[] All()
        {
            return obj.GetAll().Select(s => Cast(s)).ToArray(); ;
        }

        [WebMethod(MessageName = "ById")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.AdressSchema> GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.Schemas.AdressSchema ById(int id)
        {
            return Cast(obj.GetById(id));
        }

        [WebMethod(MessageName = "GetByAdressTyp")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[]> GetByAdressTyp(int id)
        {
            return base.getByObject1(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] ByObject1(object itemId)
        {
            return obj.GetByAdressTyp(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "GetByAdressVariant")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[]> GetByAdressVariant(int id)
        {
            return base.getByObject2(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] ByObject2(object itemId)
        {
            return obj.GetByAdressVariant(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "GetByGatuAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[]> GetByGatuAdress(int id)
        {
            return base.getByObject3(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] ByObject3(object itemId)
        {
            return obj.GetByGatuAdress(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "GetByMail")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[]> GetByMail(int id)
        {
            return base.getByObject4(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] ByObject4(object itemId)
        {
            return obj.GetByMail(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "GetByPerson")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.PersonSchema>[]> GetByPerson(int id)
        {
            return base.getByObject5(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.PersonSchema>[] ByObject5(object itemId)
        {
            return obj.GetByPerson(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.PersonSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "GetByTelefon")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[]> GetByTelefon(int id)
        {
            return base.getByObject6(id);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] ByObject6(object itemId)
        {
            return obj.GetByTelefon(Convert.ToInt32(itemId.ToString())).Select(s => new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>()
            {
                Key = Cast(s.Key),
                Value = Cast(s.Value),
            }).ToArray();
        }

        [WebMethod(MessageName = "AddAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.AdressSchema[]> AddAdress(Person.Schemas.AdressSchema[] lstItems)
        {
            return base.add(lstItems);
        }

        protected override Person.Schemas.AdressSchema[] addItems(Person.Schemas.AdressSchema[] items)
        {
            return obj.Add(items.Select(s => Cast(s)).ToList()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "AddAdressTyp")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[]> AddAdressTyp(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] lstItems)
        {
            return base.add1(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] addItems1(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] items)
        {
            return (from a in obj1.Add(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "AddAdressVariant")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[]> AddAdressVariant(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] lstItems)
        {
            return base.add2(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] addItems2(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] items)
        {
            return (from a in obj2.Add(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }


        [WebMethod(MessageName = "AddGatuAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[]> AddGatuAdress(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] lstItems)
        {
            return base.add3(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] addItems3(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] items)
        {
            return (from a in obj3.Add(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "AddMail")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[]> AddMail(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] lstItems)
        {
            return base.add4(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] addItems4(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] items)
        {
            return (from a in obj4.Add(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "AddTelefon")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[]> AddTelefon(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] lstItems)
        {
            return base.add6(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] addItems6(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] items)
        {
            return (from a in obj6.Add(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "ChangeAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.AdressSchema[]> ChangeAdress(Person.Schemas.AdressSchema[] lstItems)
        {
            return base.change(lstItems);
        }

        protected override Person.Schemas.AdressSchema[] changeItems(Person.Schemas.AdressSchema[] items)
        {
            return obj.Change(items.Select(s => Cast(s)).ToList()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "ChangeAdressTyp")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[]> ChangeAdressTyp(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] lstItems)
        {
            return base.change1(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] changeItems1(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] items)
        {
            return (from a in obj1.Change(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "ChangeAdressVariant")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[]> ChangeAdressVariant(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] lstItems)
        {
            return base.change2(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] changeItems2(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] items)
        {
            return (from a in obj2.Change(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "ChangeGatuAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[]> ChangeGatuAdress(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] lstItems)
        {
            return base.change3(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] changeItems3(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] items)
        {
            return (from a in obj3.Change(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "ChangeMail")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[]> ChangeMail(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] lstItems)
        {
            return base.change4(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] changeItems4(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] items)
        {
            return (from a in obj4.Change(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "ChangeTelefon")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[]> ChangeTelefon(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] lstItems)
        {
            return base.change6(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] changeItems6(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] items)
        {
            return (from a in obj6.Change(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "RemoveAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Person.Schemas.AdressSchema[]> RemoveAdress(Person.Schemas.AdressSchema[] lstItems)
        {
            return base.remove(lstItems);
        }

        protected override Person.Schemas.AdressSchema[] removeItems(Person.Schemas.AdressSchema[] items)
        {
            return obj.Remove(items.Select(s => Cast(s)).ToList()).Select(s => Cast(s)).ToArray();
        }

        [WebMethod(MessageName = "RemoveAdressTyp")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[]> RemoveAdressTyp(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] lstItems)
        {
            return base.remove1(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] removeItems1(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>[] items)
        {
            return (from a in obj1.Remove(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressTypSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "RemoveAdressVariant")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[]> RemoveAdressVariant(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] lstItems)
        {
            return base.remove2(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] removeItems2(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>[] items)
        {
            return (from a in obj2.Remove(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.AdressVariantSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "RemoveGatuAdress")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[]> RemoveGatuAdress(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] lstItems)
        {
            return base.remove3(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] removeItems3(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>[] items)
        {
            return (from a in obj3.Remove(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.GatuAdressSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "RemoveMail")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[]> RemoveMail(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] lstItems)
        {
            return base.remove4(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] removeItems4(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>[] items)
        {
            return (from a in obj4.Remove(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.MailSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
        }

        [WebMethod(MessageName = "RemoveTelefon")]
        [SoapHeader("WebSoapHeader", Direction = SoapHeaderDirection.InOut)]
        public Base.Schemas.TransportMessage<Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[]> RemoveTelefon(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] lstItems)
        {
            return base.remove6(lstItems);
        }

        protected override Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] removeItems6(Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>[] items)
        {
            return (from a in obj6.Remove(items.Select(s => Cast(s.Value)).ToList())
                    join b in items.Select(s => s.Key) on a.Id equals b.Id
                    select new Base.Schemas.KeyValue<Person.Schemas.AdressSchema, Person.Schemas.TelefonSchema>()
                    {
                        Key = b,
                        Value = Cast(a),
                    }).ToArray();
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
        
        protected override Person.Schemas.AdressTypSchema Cast(Person.DataLayer.AdressTyp dataItem)
        {
            return new Person.Schemas.AdressTypSchema()
            {
                Id = dataItem.Id,
                Typ = dataItem.Typ,
                SkapadDatum = dataItem.SkapadDatum,
                UpdateradDatum = dataItem.UpdateradDatum.Value,
            };
        }

        protected override Person.DataLayer.AdressTyp Cast(Person.Schemas.AdressTypSchema schemaItem)
        {
            return new Person.DataLayer.AdressTyp()
            {
                Id = schemaItem.Id,
                Typ = schemaItem.Typ,
                SkapadDatum = schemaItem.SkapadDatum,
                UpdateradDatum = schemaItem.UpdateradDatum,
            };
        }

        protected override Person.Schemas.AdressVariantSchema Cast(Person.DataLayer.AdressVariant dataItem)
        {
            return new Person.Schemas.AdressVariantSchema()
            {
                Id = dataItem.Id,
                AdressTyp_FKID = dataItem.AdressTyp_FKID,
                Variant = dataItem.Variant,
                SkapadDatum = dataItem.SkapadDatum,
                UpdateradDatum = dataItem.UpdateradDatum.Value,
            };
        }

        protected override Person.DataLayer.AdressVariant Cast(Person.Schemas.AdressVariantSchema schemaItem)
        {
            return new Person.DataLayer.AdressVariant()
            {
                Id = schemaItem.Id,
                AdressTyp_FKID = schemaItem.AdressTyp_FKID,
                Variant = schemaItem.Variant,
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
                AdressVariant_FKID = dataItem.AdressVariant_FKID,
                Person_FKID = dataItem.Person_FKID == null ? -1 : dataItem.Person_FKID.Value,
                Organisation_FKID = dataItem.Organisation_FKID == null ? -1 : dataItem.Organisation_FKID.Value,
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
                AdressVariant_FKID = schemaItem.AdressVariant_FKID,
                Person_FKID = schemaItem.Person_FKID,
                Organisation_FKID = schemaItem.Organisation_FKID,
                SkapadDatum = schemaItem.SkapadDatum,
                UpdateradDatum = schemaItem.UpdateradDatum,
            };
        }

        protected override Person.Schemas.TelefonSchema Cast(Person.DataLayer.Telefon dataItem)
        {
            return new Person.Schemas.TelefonSchema()
            {
                Id = dataItem.Id,
                Adress_FKID = dataItem.Adress_FKID,
                AdressTyp_FKID = dataItem.AdressTyp_FKID != null ? dataItem.AdressTyp_FKID.Value : -1,
                AdressVariant_FKID = dataItem.AdressVariant_FKID != null ? dataItem.AdressVariant_FKID.Value : -1,
                TelefonNummer = Convert.ToInt32(dataItem.TelefonNummer),
                SkapadDatum = dataItem.SkapadDatum,
                UpdateradDatum = dataItem.UpdateradDatum != null ? dataItem.UpdateradDatum.Value : DateTime.MinValue,
            };
        }

        protected override Person.DataLayer.Telefon Cast(Person.Schemas.TelefonSchema schemaItem)
        {
            return new Person.DataLayer.Telefon()
            {
                Id = schemaItem.Id,
                Adress_FKID = schemaItem.Adress_FKID,
                AdressTyp_FKID = schemaItem.AdressTyp_FKID,
                AdressVariant_FKID = schemaItem.AdressVariant_FKID,
                TelefonNummer = schemaItem.TelefonNummer,
                SkapadDatum = schemaItem.SkapadDatum,
                UpdateradDatum = schemaItem.UpdateradDatum,
            };
        }
    }
}
