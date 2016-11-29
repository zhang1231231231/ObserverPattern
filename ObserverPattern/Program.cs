using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public abstract class TenXun
    {
        private List<IObserver> observers = new List<IObserver>();
        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXun(string symbol,string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

    #region 新增订阅号列表的维护操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            if (observers.Count>0)
            {
                observers.Remove(ob);
            }
        }
    #endregion

        public void Update()
        {
            //遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob!=null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }


    }

    //具体订阅号
    public class TenXunGame:TenXun
    {
        public TenXunGame(string symbol,string info)
            :base(symbol,info)
        {

        }
    }


    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    public class Subscriber:IObserver
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("Notfied {0} of {1}'s " + "info is :{2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game publicshed ....");

            //添加订阅者
            tenXun.AddObserver(new Subscriber("Learning Hard"));
            tenXun.AddObserver(new Subscriber("Tom"));
            tenXun.Update();
            Console.ReadLine();
        }
    }
}
