using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLearning
{
    /// <summary>
    /// 接口
    /// </summary>
    public interface Shape
    {
        string draw();
    }
    /// <summary>
    /// 实现接口的类
    /// </summary>
    public class Rectangle : Shape
    {
        public string draw()
        {
            return "Rectangle";
        }
    }
    public class Circle : Shape
    {
        public string draw()
        {
            return "Circle";
        }
    }
    /// <summary>
    /// 工厂方法
    /// </summary>
    public class ShapeFactory
    {
        //使用 getShape 方法获取形状类型的对象
        public Shape getShape(String shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType == "CIRCLE")
            {
                return new Circle();
            }
            else if (shapeType == "RECTANGLE")
            {
                return new Rectangle();
            }

            return null;
        }
    }
    /// <summary>
    /// 最常用的设计模式之一。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
    /// 意图：定义一个创建对象的接口，让其子类自己决定实例化哪一个工厂类，工厂模式使其创建过程延迟到子类进行。
    /// 主要解决：主要解决接口选择的问题。
    /// 何时使用：我们明确地计划不同条件下创建不同实例时。
    /// 如何解决：让其子类实现工厂接口，返回的也是一个抽象的产品。
    /// 使用场景：
    /// 1、日志记录器：记录可能记录到本地硬盘、系统事件、远程服务器等，用户可以选择记录日志到什么地方。
    ///2、 数据库访问，当用户不知道最后系统采用哪一类数据库，以及数据库可能有变化时。
    ///3、 设计一个连接服务器的框架，需要三个协议，"POP3"、"IMAP"、"HTTP"，可以把这三个作为产品类，共同实现一个接口。
    /// </summary>
    public class FactoryPattern
    {

        //使用工厂方法
        public void Use()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            //通过值得到对象
            Shape ci = shapeFactory.getShape("CIRCLE");
            Shape re = shapeFactory.getShape("RECTANGLE");
            //使用方法
            string cis=ci.draw();
            string res = re.draw();
        }
      
    }
}
