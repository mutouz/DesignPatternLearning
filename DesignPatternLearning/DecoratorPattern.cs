using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLearning
{
    /// <summary>
    /// 允许向一个现有的对象添加新的功能，同时又不改变其结构。这种类型的设计模式属于结构型模式，它是作为现有的类的一个包装。
    /// 这种模式创建了一个装饰类，用来包装原有的类，并在保持类方法签名完整性的前提下，提供了额外的功能。
    /// 我们通过下面的实例来演示装饰器模式的用法。其中，我们将把一个形状装饰上不同的颜色，同时又不改变形状类。
    /// 装饰器
    /// </summary>
    public  class DecoratorPattern
    {

    }
    /// <summary>
    /// MainApp结构的启动类
    ///装饰器设计模式。
    /// </ summary>
    public class MainApp
    {
        /// <summary>
        ///控制台应用程序的入口点。
        /// </ summary>
        public void GetData()
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();
            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// “组件”抽象类
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    /// 'ConcreteComponent'类
    /// </summary>
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component!=null)
            {
                component.Operation();
            }
        }    
    }
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecratorA.Operation()");
        }
    }
    class ConcreteDecoratorB : Decorator 
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");

        }
        void AddedBehavior()
        {
        }
    }
}
