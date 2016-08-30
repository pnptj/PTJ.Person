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
    public class AdressTypHanterare : Base<int, Person.DataLayer.AdressTypHanterare, Person.DataLayer.AdressTyp, Person.DataLayer.Adress, Person.DataLayer.AdressVariant, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public AdressTypHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.AdressTypHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.AdressTypHanterare(); }

            lstResults = new List<Person.DataLayer.AdressTyp>();
            result = new Person.DataLayer.AdressTyp();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.Adress>>();
        }

        public List<Person.DataLayer.AdressTyp> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.AdressTyp> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.AdressTyp GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.AdressTyp ById(int id)
        {
            return obj.GetById(id);
        }

        public List<Person.DataLayer.AdressTyp> GetByTyp(string name)
        {
            return base.getBy1(name);
        }

        protected override List<AdressTyp> By1(object variable)
        {
            return obj.GetByName(variable.ToString());
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.Adress>> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.Adress>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.Adress>>)obj.GetByRelation(Person.DataLayer.AdressTypHanterare.Relations.Adress, ((int)itemId)));
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.AdressVariant>> GetByAdressVariant(int id)
        {
            return base.getByObject2(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.AdressVariant>> byObject2(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.AdressTyp, Person.DataLayer.AdressVariant>>)obj.GetByRelation(Person.DataLayer.AdressTypHanterare.Relations.AdressVariant, ((int)itemId)));
        }

        public List<Person.DataLayer.AdressTyp> Add(List<Person.DataLayer.AdressTyp> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.AdressTyp> addItems(List<Person.DataLayer.AdressTyp> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.AdressTyp> Change(List<Person.DataLayer.AdressTyp> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.AdressTyp> changeItems(List<Person.DataLayer.AdressTyp> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.AdressTyp> Remove(List<Person.DataLayer.AdressTyp> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.AdressTyp> removeItems(List<Person.DataLayer.AdressTyp> items)
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

        public override bool ItemsExists(List<Person.DataLayer.AdressTyp> items)
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
