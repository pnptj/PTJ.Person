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
    public class PersonHanterare :  Base<int, Person.DataLayer.PersonHanterare, Person.DataLayer.Person, Person.DataLayer.Adress, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public PersonHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.PersonHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.PersonHanterare(); }

            lstResults = new List<Person.DataLayer.Person>();
            result = new Person.DataLayer.Person();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.Person, Person.DataLayer.Adress>>();
        }

        public List<Person.DataLayer.Person> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.Person> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.Person GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.Person getById(int id)
        {
            return obj.GetById(id);
        }

        public List<Person.DataLayer.Person> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<Person.DataLayer.Person> By1(object variable)
        {
            return obj.GetByName(variable.ToString());
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Person, Person.DataLayer.Adress>> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Person, Person.DataLayer.Adress>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Person, Person.DataLayer.Adress>>)obj.GetByRelation(Person.DataLayer.PersonHanterare.Relations.Adress, ((int)itemId)));
        }

        public List<Person.DataLayer.Person> Add(List<Person.DataLayer.Person> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.Person> addItems(List<Person.DataLayer.Person> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.Person> Change(List<Person.DataLayer.Person> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.Person> changeItems(List<Person.DataLayer.Person> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.Person> Remove(List<Person.DataLayer.Person> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.Person> removeItems(List<Person.DataLayer.Person> items)
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

        public override bool ItemsExists(List<Person.DataLayer.Person> items)
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
