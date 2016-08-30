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
    public class TelefonHanterare : Base<int, Person.DataLayer.TelefonHanterare, Person.DataLayer.Telefon, Person.DataLayer.Adress, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public TelefonHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.TelefonHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.TelefonHanterare(); }

            lstResults = new List<Person.DataLayer.Telefon>();
            result = new Person.DataLayer.Telefon();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.Telefon, Person.DataLayer.Adress>>();
        }

        public List<Person.DataLayer.Telefon> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.Telefon> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.Telefon GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.Telefon getById(int id)
        {
            return obj.GetById(id);
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Telefon, Person.DataLayer.Adress>> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Telefon, Person.DataLayer.Adress>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Telefon, Person.DataLayer.Adress>>)obj.GetByRelation(Person.DataLayer.TelefonHanterare.Relations.Adress, ((int)itemId)));
        }

        public List<Person.DataLayer.Telefon> Add(List<Person.DataLayer.Telefon> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.Telefon> addItems(List<Person.DataLayer.Telefon> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.Telefon> Change(List<Person.DataLayer.Telefon> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.Telefon> changeItems(List<Person.DataLayer.Telefon> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.Telefon> Remove(List<Person.DataLayer.Telefon> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.Telefon> removeItems(List<Person.DataLayer.Telefon> items)
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

        public override bool ItemsExists(List<Person.DataLayer.Telefon> items)
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
