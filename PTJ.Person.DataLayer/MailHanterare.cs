using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class MailHanterare : Base<int, Mail, DBPersonDataContext, int, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            Adress,
        }

        public MailHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<Mail>();
            result = new Mail();
        }

        public List<Mail> GetAll()
        {
            return base.getAll();
        }

        protected override List<Mail> all()
        {
            return ctx.Mails.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true).OrderBy(s => s.MailAdress).ToList();
        }

        public bool Exists(List<Mail> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<Mail> lstItems)
        {
            return (from a in ctx.Mails
                    where lstItems.Select(s => s.MailAdress.ToLower()).Contains(a.MailAdress.ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.Mails
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public Mail GetById(int id)
        {
            return base.getById(id);
        }

        protected override Mail byId(int id)
        {
            return ctx.Mails.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public List<Mail> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<Mail> by1(object value)
        {
            return ctx.Mails
                        .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView))
                        .Where(w => w.MailAdress.ToLower().IndexOf(value.ToString().ToLower()) > -1)
                        .OrderBy(o => o.MailAdress.ToLower()).ToList();
        }

        public object GetByRelation(Relations relation, int id)
        {
            return base.getByRelation(relation, id);
        }

        protected override bool isRelation1(string relation)
        {
            return Relations.Adress.ToString() == relation;
        }

        protected override object getRelation1(int id)
        {
            return (from a in ctx.Mails
                    join b in ctx.Adresses on a.Adress_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Mail, Adress>() { Key = a, Value = b }).Distinct().ToList();
        }

        public List<Mail> Add(List<Mail> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<Mail> addItems(List<Mail> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.Mails.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.Mails.Count() != 0)
            {
                Id = ctx.Mails.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<Mail> Update(List<Mail> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<Mail> updateItems(List<Mail> lstItems)
        {
            List<Mail> lstMailResult = new List<Mail>();
            foreach (var item in (from au in ctx.Mails
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.MailAdress = updateItem.MailAdress;
                item.Adress_FKID = updateItem.Adress_FKID;
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.UpdateradDatum = DateTime.Now;
                lstMailResult.AddRange(this.Add(new List<Mail>() { item }));
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        public List<Mail> Delete(List<Mail> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<Mail> deleteItems(List<Mail> lstItems)
        {
            foreach (var item in (from au in ctx.Mails
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.MailAdress = updateItem.MailAdress;
                item.Adress_FKID = updateItem.Adress_FKID;
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }
    }
}
