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
    public class MailHanterare : Base<int, Person.DataLayer.MailHanterare, Person.DataLayer.Mail, Person.DataLayer.Adress, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public MailHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            if (timeView != DateTime.MinValue) { obj = new Person.DataLayer.MailHanterare() { TimeView = base.TimeView }; }
            else { obj = new Person.DataLayer.MailHanterare(); }

            lstResults = new List<Person.DataLayer.Mail>();
            result = new Person.DataLayer.Mail();
            lstResults1 = new List<Base.Schemas.KeyValue<Person.DataLayer.Mail, Person.DataLayer.Adress>>();
        }

        public List<Person.DataLayer.Mail> GetAll()
        {
            return base.getAll();
        }

        protected override List<Person.DataLayer.Mail> All()
        {
            return obj.GetAll();
        }

        public Person.DataLayer.Mail GetById(int id)
        {
            return base.getById(id);
        }

        protected override Person.DataLayer.Mail getById(int id)
        {
            return obj.GetById(id);
        }

        public List<Base.Schemas.KeyValue<Person.DataLayer.Mail, Person.DataLayer.Adress>> GetByAdress(int id)
        {
            return base.getByObject1(id);
        }

        public List<Person.DataLayer.Mail> GetByMailAdress(string name)
        {
            return obj.GetByName(name);
        }

        protected override List<Base.Schemas.KeyValue<Person.DataLayer.Mail, Person.DataLayer.Adress>> byObject1(object itemId)
        {
            return ((List<Base.Schemas.KeyValue<Person.DataLayer.Mail, Person.DataLayer.Adress>>)obj.GetByRelation(Person.DataLayer.MailHanterare.Relations.Adress, ((int)itemId)));
        }

        public List<Person.DataLayer.Mail> Add(List<Person.DataLayer.Mail> items)
        {
            return base.add(items);
        }

        protected override List<Person.DataLayer.Mail> addItems(List<Person.DataLayer.Mail> items)
        {
            return obj.Add(items);
        }

        public List<Person.DataLayer.Mail> Change(List<Person.DataLayer.Mail> items)
        {
            return base.change(items);
        }

        protected override List<Person.DataLayer.Mail> changeItems(List<Person.DataLayer.Mail> items)
        {
            return obj.Update(items);
        }

        public List<Person.DataLayer.Mail> Remove(List<Person.DataLayer.Mail> items)
        {
            return base.remove(items);
        }

        protected override List<Person.DataLayer.Mail> removeItems(List<Person.DataLayer.Mail> items)
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

        public override bool ItemsExists(List<Person.DataLayer.Mail> items)
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
