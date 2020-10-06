using DAbstractFactoryPattern;
using FilterPatterns;
using SingletonPattern;
using System;
using static FilterPatterns.FilterPattern;

namespace DesignPatternLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            // 设计模式 - 可复用的面向对象软件元素

            #region Factory Pattern 工厂模式
            FactoryPattern factoryPattern = new FactoryPattern();
            factoryPattern.Use();
            #endregion

            #region Abstract Factory Pattern 抽象工厂模式
            AbstractFactoryPatternDemo abstractFactoryPatternDemo = new AbstractFactoryPatternDemo();
            abstractFactoryPatternDemo.Use();
            #endregion

            #region Singleton Pattern 单例模式
            SingletonPatternDemo singleton = new SingletonPatternDemo();
            singleton.Use();
            #endregion

            #region Filter Pattern 过滤器模式    
            CriteriaPattrnDemo filter = new CriteriaPattrnDemo();
            filter.Use();
            #endregion

            #region Decorator Pattern 装饰器
            MainApp mainApp = new MainApp();
            mainApp.GetData();
            #endregion

            #region Builder Pattern 建造者模式

            #endregion



        }


    }
}
