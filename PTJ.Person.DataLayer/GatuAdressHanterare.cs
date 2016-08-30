using PTJ.Base.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTJ.Person.DataLayer
{
    public class GatuAdressHanterare : Base<int, GatuAdress, DBPersonDataContext, int, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing>
    {
        public enum Relations
        {
            Adress,
        }

        public GatuAdressHanterare()
        {
            initiate();
        }

        protected override void initiate()
        {
            timeView = DateTime.Now;
            ctx = new DBPersonDataContext();
            lstResults = new List<GatuAdress>();
            result = new GatuAdress();
        }

        public List<GatuAdress> GetAll()
        {
            return base.getAll();
        }

        protected override List<GatuAdress> all()
        {
            return ctx.GatuAdresses
                    .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView) == true)
                    .OrderBy(s => s.AdressRad1.Trim() + ", "
                                + s.AdressRad2.Trim() + ", "
                                + s.AdressRad3.Trim() + ", "
                                + s.AdressRad4.Trim() + ", "
                                + s.AdressRad5.Trim() + ", "
                                + s.Postnummer.ToString().Trim() + ", "
                                + s.Stad.Trim() + ", "
                                + s.Land.Trim()).ToList();
        }

        public bool Exists(List<GatuAdress> lstItems)
        {
            return base.exists(lstItems);
        }

        protected override bool existsItems(List<GatuAdress> lstItems)
        {
            return (from a in ctx.GatuAdresses
                    where lstItems
                        .Select(s => s.AdressRad1.Trim() + ", "
                                    + s.AdressRad2.Trim() + ", "
                                    + s.AdressRad3.Trim() + ", "
                                    + s.AdressRad4.Trim() + ", "
                                    + s.AdressRad5.Trim() + ", "
                                    + s.Postnummer.ToString().Trim() + ", "
                                    + s.Stad.Trim() + ", "
                                    + s.Land.Trim().ToLower())
                                    .Contains(a.AdressRad1.Trim() + ", "
                                            + a.AdressRad2.Trim() + ", "
                                            + a.AdressRad3.Trim() + ", "
                                            + a.AdressRad4.Trim() + ", "
                                            + a.AdressRad5.Trim() + ", "
                                            + a.Postnummer.ToString().Trim() + ", "
                                            + a.Stad.Trim() + ", "
                                            + a.Land.Trim().ToLower())
                    select a).Count() > 0;
        }

        public bool Exists(List<int> lstIds)
        {
            return base.exists(lstIds);
        }

        protected override bool existsItems(List<int> lstIds)
        {
            return (from a in ctx.GatuAdresses
                    where lstIds.Select(s => s).Contains(a.Id)
                    select a).Count() > 0;
        }

        public GatuAdress GetById(int id)
        {
            return base.getById(id);
        }

        protected override GatuAdress byId(int id)
        {
            return ctx.GatuAdresses.Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView)).Single(s => s.Id == id);
        }

        public List<GatuAdress> GetByName(string name)
        {
            return base.getBy1(name);
        }

        protected override List<GatuAdress> by1(object value)
        {
            return ctx.GatuAdresses
                        .Where(w => ((w.UpdateradDatum.Value == null || w.UpdateradDatum.Value <= timeView) && w.SkapadDatum <= timeView))
                        .Where(w => (w.AdressRad1.Trim() + ", "
                                    + w.AdressRad2.Trim() + ", "
                                    + w.AdressRad3.Trim() + ", "
                                    + w.AdressRad4.Trim() + ", "
                                    + w.AdressRad5.Trim() + ", "
                                    + w.Postnummer.ToString().Trim() + ", "
                                    + w.Stad.Trim() + ", "
                                    + w.Land.Trim().ToLower()).IndexOf(value.ToString().ToLower()) >-1 )
                        .OrderBy(o => o.AdressRad1.Trim() + ", "
                                    + o.AdressRad2.Trim() + ", "
                                    + o.AdressRad3.Trim() + ", "
                                    + o.AdressRad4.Trim() + ", "
                                    + o.AdressRad5.Trim() + ", "
                                    + o.Postnummer.ToString().Trim() + ", "
                                    + o.Stad.Trim() + ", "
                                    + o.Land.Trim().ToLower()).ToList();
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
            return (from a in ctx.GatuAdresses
                    join b in ctx.Adresses on a.Adress_FKID equals b.Id
                    where b.Id == id
                    select new Base.Schemas.KeyValue<GatuAdress, Adress>() { Key = a, Value = b }).Distinct().ToList();
        }

        public List<GatuAdress> Add(List<GatuAdress> lstItems)
        {
            return base.add(lstItems);
        }

        protected override List<GatuAdress> addItems(List<GatuAdress> lstItems)
        {
            int newId = getNewId();
            lstItems.ForEach(f => f.Id = newId++);
            lstItems.ForEach(f => f.SkapadDatum = DateTime.Now); lstItems.ForEach(f => f.UpdateradDatum = DBDateTimeHelper.getDefaultDateTime());

            ctx.GatuAdresses.InsertAllOnSubmit(lstItems);
            ctx.SubmitChanges();
            return lstItems;
        }

        private int getNewId()
        {
            int Id = 1;
            if (ctx.GatuAdresses.Count() != 0)
            {
                Id = ctx.GatuAdresses.Select(s => s.Id).Max() + 1;
            }
            return Id;
        }

        public List<GatuAdress> Update(List<GatuAdress> lstItems)
        {
            return base.update(lstItems);
        }

        protected override List<GatuAdress> updateItems(List<GatuAdress> lstItems)
        {
            List<GatuAdress> lstGatuAdressResult = new List<GatuAdress>();
            foreach (var item in (from au in ctx.GatuAdresses
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.Adress_FKID = updateItem.Adress_FKID;
                item.AdressRad1 = updateItem.AdressRad1;
                item.AdressRad2 = updateItem.AdressRad2;
                item.AdressRad3 = updateItem.AdressRad3;
                item.AdressRad4 = updateItem.AdressRad4;
                item.AdressRad5 = updateItem.AdressRad5;
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.Postnummer = updateItem.Postnummer;
                item.Stad = updateItem.Stad;
                item.Land = updateItem.Land;
                item.UpdateradDatum = DateTime.Now;
                lstGatuAdressResult.AddRange(this.Add(new List<GatuAdress>() { item }));
            }
            ctx.SubmitChanges();
            return lstItems;
        }

        public List<GatuAdress> Delete(List<GatuAdress> lstItems)
        {
            return base.delete(lstItems);
        }

        protected override List<GatuAdress> deleteItems(List<GatuAdress> lstItems)
        {
            foreach (var item in (from au in ctx.GatuAdresses
                                  where lstItems.Select(s => s.Id).Contains(au.Id)
                                  select au))
            {
                var updateItem = lstItems.Where(w => w.Id == item.Id).Single();
                item.Adress_FKID = updateItem.Adress_FKID;
                item.AdressRad1 = updateItem.AdressRad1;
                item.AdressRad2 = updateItem.AdressRad2;
                item.AdressRad3 = updateItem.AdressRad3;
                item.AdressRad4 = updateItem.AdressRad4;
                item.AdressRad5 = updateItem.AdressRad5;
                item.AdressTyp_FKID = updateItem.AdressTyp_FKID;
                item.AdressVariant_FKID = updateItem.AdressVariant_FKID;
                item.Postnummer = updateItem.Postnummer;
                item.Stad = updateItem.Stad;
                item.Land = updateItem.Land;
                item.UpdateradDatum = DateTime.Now;
            }
            ctx.SubmitChanges();
            return lstItems;
        }
    }
}
