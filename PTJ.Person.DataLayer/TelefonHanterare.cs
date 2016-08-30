using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class TelefonHanterare : Base<int, Telefon, DBPersonDataContext, int, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            Adress,
        }

        public TelefonHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<Telefon>();
            result = new Telefon();
        }

        public List<Telefon> GetAll()
        {
            return base.getAll();
        }

        protected override List<Telefon> all()
        {
            return ctx.Telefons.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true).OrderBy(s => s.TelefonNummer.ToString().Trim()).ToList();
        }

        public bool Exists(List<Telefon> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<Telefon> lstItems)
        {
            return (from a in ctx.Telefons
                    where lstItems.Select(s => s.TelefonNummer.ToString().Trim().ToLower()).Contains(a.TelefonNummer.ToString().Trim().ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.Telefons
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public Telefon GetById(int id)
        {
            return base.getById(id);
        }

        protected override Telefon byId(int id)
        {
            return ctx.Telefons.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public List<Telefon> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<Telefon> by1(object value)
        {
            return ctx.Telefons
                        .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView))
                        .Where(w => w.TelefonNummer.ToString().Trim().ToLower().IndexOf(value.ToString().ToLower()) > -1)
                        .OrderBy(o => o.TelefonNummer.ToString().Trim().ToLower()).ToList();
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
            return (from a in ctx.Telefons
                    join b in ctx.Adresses on a.Adress_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<Telefon, Adress>() { Key = a, Value = b }).Distinct().ToList();
        }

        public List<Telefon> Add(List<Telefon> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<Telefon> addItems(List<Telefon> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.Telefons.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.Telefons.Count() != 0)
            {
                Id = ctx.Telefons.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<Telefon> Update(List<Telefon> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<Telefon> updateItems(List<Telefon> lstItems)
        {
            List<Telefon> lstTelefonResult = new List<Telefon>();
            foreach (var item in (from au in ctx.Telefons
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.Adress_FKID = updateItem.Adress_FKID;
                item.TelefonNummer = updateItem.TelefonNummer;
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.UpdateradDatum = DateTime.Now;
                lstTelefonResult.AddRange(this.Add(new List<Telefon>() { item }));
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        public List<Telefon> Delete(List<Telefon> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<Telefon> deleteItems(List<Telefon> lstItems)
        {
            foreach (var item in (from au in ctx.Telefons
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.Adress_FKID = updateItem.Adress_FKID;
                item.TelefonNummer = updateItem.TelefonNummer;
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }
    }
}
