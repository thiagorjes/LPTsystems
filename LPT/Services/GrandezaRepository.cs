using System;
using System.Collections.Generic;
using System.Linq;
using LPT.Interfaces;
using LPT.Models;

namespace LPT.Services
{
    public class GrandezaRepository : IGenericRepository
    {
        private LPTContext context;
        private List<Grandeza> _all;
        public GrandezaRepository(LPTContext ctx)
        {
            InitializeData(ctx);
        }
        private void InitializeData(LPTContext ctx)
        {
            context = ctx;
            _all = context.Grandeza.ToList();
        }
        IEnumerable<object> IGenericRepository.All
        {
            get
            {
                return _all;
            }
        }
        public object Create(object p){
            try
            {
                Grandeza r = (context.Grandeza.Add((Grandeza)p)).Entity;
                context.SaveChanges();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Read(int IdGrandeza){
            try
            {
                Grandeza r = (from p in context.Grandeza where p.IdGrandeza==IdGrandeza select p).FirstOrDefault<Grandeza>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(int IdGrandeza,object newObject ){
            try
            {
                Grandeza r = (from p in context.Grandeza where p.IdGrandeza==IdGrandeza select p).FirstOrDefault<Grandeza>();
                foreach(var att in ((Grandeza) newObject).GetType().GetProperties()){
                if(!att.Name.Equals("IdGrandeza"))r.GetType().GetProperty(att.Name).SetValue(r,att.GetValue(newObject));
                }
                context.Entry(r).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string Delete(int IdGrandeza){
            try
            {
                var r = (from p in context.Grandeza where p.IdGrandeza==IdGrandeza select p).FirstOrDefault<Grandeza>();
                context.Grandeza.Remove(r);
                context.SaveChanges();
                return "Grandeza removido com sucesso!";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Falha ao remover Grandeza!";
            }
        }
        public List<object> ReadManyByParam(string Descricao){
            try
            {
                List<object> r = (from p in context.Grandeza where p.Descricao.Contains(Descricao) select p).ToList<object>();
                return r;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public List<object> GrandezaAll(){
        return _all.ToList<object>();
        }
    }
}