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
    public class AdressVariantHanterare : Base<int, Person.DataLayer.AdressVariantHanterare, Person.DataLayer.AdressVariant, Person.DataLayer.Adress, Person.DataLayer.AdressTyp, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public AdressVariantHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.AdressVariantHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.AdressVariantHanterare(); }

            lstResults = new List<Person.DataLayer.AdressVariant>();
            result = new Person.DataLayer.AdressVariant();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.Adress>>();
        }

        public List<Person.DataLayer.AdressVariant> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.AdressVariant> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.AdressVariant GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.AdressVariant getById(int id)
        {
            return obj.GetById(id);
        }

        public List<Person.DataLayer.AdressVariant> GetByVariant(string name)
        {
            return base.getBy1(name);
        }

        protected override List<Person.DataLayer.AdressVariant> By1(object variable)
        {
            return obj.GetByName(variable.ToString());
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.Adress>> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.Adress>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.Adress>>)obj.GetByRelation(Person.DataLayer.AdressVariantHanterare.Relations.Adress, ((int)itemId)));
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.AdressTyp>> GetByAdressTyp(int id)
        {
            return base.getByObject2(Convert.ToInt32(id));
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.AdressTyp>> byObject2(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.AdressVariant, Person.DataLayer.AdressTyp>>)obj.GetByRelation(Person.DataLayer.AdressVariantHanterare.Relations.AdressTyp, ((int)itemId)));
        }

        public List<Person.DataLayer.AdressVariant> Add(List<Person.DataLayer.AdressVariant> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.AdressVariant> addItems(List<Person.DataLayer.AdressVariant> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.AdressVariant> Change(List<Person.DataLayer.AdressVariant> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.AdressVariant> changeItems(List<Person.DataLayer.AdressVariant> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.AdressVariant> Remove(List<Person.DataLayer.AdressVariant> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.AdressVariant> removeItems(List<Person.DataLayer.AdressVariant> items)
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

        public override bool ItemsExists(List<Person.DataLayer.AdressVariant> items)
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
