using PTJ.Base.BusinessRules;
using PTJ.Person.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using PTJ;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.BusinessRules
{
    public class AdressHanterare : Base<int, Person.DataLayer.AdressHanterare, Person.DataLayer.Adress, Person.DataLayer.Person, Person.DataLayer.AdressTyp, Person.DataLayer.AdressVariant, Person.DataLayer.GatuAdress, Person.DataLayer.Telefon, Person.DataLayer.Mail, Nothing, Nothing>
    {
        public AdressHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.AdressHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.AdressHanterare(); }

            lstResults = new List<Person.DataLayer.Adress>();
            result = new Person.DataLayer.Adress();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Person>>();
        }

        public List<Person.DataLayer.Adress> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.Adress> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.Adress GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.Adress getById(int id)
        {
            return obj.GetById(id);
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Person>> GetByPerson(int id)
        {
            return base.getByObject1(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Person>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Person>>)obj.GetByRelation(Person.DataLayer.AdressHanterare.Relations.Person, ((int)itemId)));
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.AdressTyp>> GetByAdressTyp(int id)
        {
            return base.getByObject2(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.AdressTyp>> byObject2(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.AdressTyp>>)obj.GetByRelation(Person.DataLayer.AdressHanterare.Relations.AdressTyp, ((int)itemId)));
        }
 
        public List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.AdressVariant>> GetByAdressVariant(int id)
        {
            return base.getByObject3(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.AdressVariant>> byObject3(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.AdressVariant>>)obj.GetByRelation(Person.DataLayer.AdressHanterare.Relations.AdressVariant, ((int)itemId)));
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.GatuAdress>> GetByGatuAdress(int id)
        {
            return base.getByObject4(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.GatuAdress>> byObject4(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.GatuAdress>>)obj.GetByRelation(Person.DataLayer.AdressHanterare.Relations.GatuAdress, ((int)itemId)));
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Telefon>> GetByTelefon(int id)
        {
            return base.getByObject5(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Telefon>> byObject5(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Telefon>>)obj.GetByRelation(Person.DataLayer.AdressHanterare.Relations.Telefon, ((int)itemId)));
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Mail>> GetByMail(int id)
        {
            return base.getByObject6(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Mail>> byObject6(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Adress, Person.DataLayer.Mail>>)obj.GetByRelation(Person.DataLayer.AdressHanterare.Relations.Mail, ((int)itemId)));
        }

        public List<Person.DataLayer.Adress> Add(List<Person.DataLayer.Adress> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.Adress> addItems(List<Person.DataLayer.Adress> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.Adress> Change(List<Person.DataLayer.Adress> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.Adress> changeItems(List<Person.DataLayer.Adress> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.Adress> Remove(List<Person.DataLayer.Adress> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.Adress> removeItems(List<Person.DataLayer.Adress> items)
        {
            return obj.Delete(items);
        }

        protected override void setObjectTimeStamp()
        {
            if (base.isTimeViewSet())
            {
                obj.TimeView = base.TimeView;
            }
        }

        public override bool ItemsExists(List<Person.DataLayer.Adress> items)
        {
            return obj.Exists(items);
        }

        public override bool ItemsExists(List<int> ids)
        {
            return obj.Exists(ids);
        }

        protected override void setMessageChannel()
        {
            obj.MsgChannel = base.msgChannel;
        }

        public override List<Base.MessageChannel.Message> getObjectMessages()
        {
            return obj.MsgChannel.Get();
        }
    }
}
