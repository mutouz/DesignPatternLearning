using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{
    public class SingleObject
    {
        //创建 SingleObject 的一个对象
        private static SingleObject instance = new SingleObject();
        //让构造函数为 private，这样该类就不会被实例化
          private SingleObject() { }
        //获取唯一的实例化对象
        public static SingleObject getInstance()
        {
            return instance;
        }
        public string  ShowMessage()
        {
            return "show";
        }
    }
    #region 双锁机制实现
    public sealed class Singleton
    {
        //存储值
        public List<Dictionary<string, object>> diction;
        //构建
        private volatile static Singleton instance = null;//volatile 可以禁止
        private static readonly object padlock = new object();
        /// <summary>
        /// 构造方法
        /// </summary>
        Singleton()
        {

        }
        public static Singleton Instance
        {
            get
            {
                if (instance==null)
                {
                    lock(padlock)
                    {
                        if (instance==null)
                        {
                            var tmp = new Singleton();
                            //确保实例已正确初始化，
                            //只有这样，它才会分配静态变量。
                            //官方文档是说Thread.MemoryBarrier()，保证之前的数据存取优先于MemoryBarrier执行，只有在多CPU下才需要使用
                            System.Threading.Thread.MemoryBarrier();
                            instance = tmp;
                            instance. diction = new List<Dictionary<string, object>>();
                        }
                    }
                }
                return instance;
            }
        }
    }
    #endregion


    /// <summary>
    /// 这个类提供了一种访问其唯一的对象的方式，可以直接访问，不需要实例化该类的对象。
    /// 1、单例类只能有一个实例。
    ///2、单例类必须自己创建自己的唯一实例。
    ///3、单例类必须给所有其他对象提供这一实
    ///应用实例
    ///1、一个班级只有一个班主任。
    ////2、Windows 是多进程多线程的，在操作一个文件的时候，就不可避免地出现多个进程或线程同时操作一个文件的现象，所以所有文件的处理必须通过唯一的实例来进行。
    ///3、一些设备管理器常常设计为单例模式，比如一个电脑有两台打印机，在输出的时候就要处理不能两台打印机打印同一个文件。
    ///场景
    ///1、要求生产唯一序列号。
    ///2、WEB 中的计数器，不用每次刷新都在数据库里加一次，用单例先缓存起来。
    ///3、创建的一个对象需要消耗的资源过多，比如 I/O 与数据库的连接等。
    /// </summary>
    public class SingletonPatternDemo
   {
        public void Use()
        {
            Singleton singleton = Singleton.Instance;
            //生成单例
            SingleObject obj = SingleObject.getInstance();
            //获取数据
            var a = obj.ShowMessage();
            Test();
            var b = singleton.diction;
           Test();
            b = singleton.diction;

        }
        public void Test()
        {
            //线程安全的方法双锁机制实现
            Singleton singleton = Singleton.Instance;
            var di = new Dictionary<string, object>();
            di.Add("a","a1");
            singleton.diction.Add(di);
        }
    }
}
