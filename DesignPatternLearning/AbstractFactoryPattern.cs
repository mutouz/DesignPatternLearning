using System;
using System.Collections.Generic;
using System.Text;

namespace DAbstractFactoryPattern
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
    /// 颜色接口及相关实现
    /// </summary>
    public interface Color
    {
        string fill();
    }
    public class Red : Color
    {
        public string fill()
        {
            return "RED";
        }
    }
    public class Blue : Color
    {
        public string fill()
        {
            return "BLUE";
        }
    }
    /// <summary>
    /// 是围绕一个超级工厂创建其他工厂。该超级工厂又称为其他工厂的工厂。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
    /// 在抽象工厂模式中，接口是负责创建一个相关对象的工厂，不需要显式指定它们的类。每个生成的工厂都能按照工厂模式提供对象。
    /// 意图：提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类。
    /// 主要解决：主要解决接口选择的问题。
    /// 何时使用：系统的产品有多于一个的产品族，而系统只消费其中某一族的产品。
    /// 优点：当一个产品族中的多个对象被设计成一起工作时，它能保证客户端始终只使用同一个产品族中的对象。
    ///缺点：产品族扩展非常困难，要增加一个系列的某一产品，既要在抽象的 Creator 里加代码，又要在具体的里面加代码。
    ///使用场景： 1、QQ 换皮肤，一整套一起换。 2、生成不同操作系统的程序。
    ///注意事项：产品族难扩展，产品等级易扩展。
    /// </summary>
    public abstract class AbstractFactoryPattern
    {
        //管理接口工厂
        public abstract Color getColor(string color);
        public abstract Shape getShape(string shape);

    }
    /// <summary>
    /// 实现管理Shape接口工厂类
    /// </summary>

    public class ShapeFactory : AbstractFactoryPattern
    {
        //调用颜色管理工厂接口
        public override Color getColor(string color)
        {
            return null;
        }
        //调用管理Shape的管理工厂接口
        public override Shape getShape(string shape)
        {
            if (shape == null)
            {
                return null;
            }
            if (shape == "CIRCLE")
            {
                return new Circle();
            }
            else if (shape == "RECTANGLE")
            {
                return new Rectangle();
            }

            return null;
        }
    }
    /// <summary>
    /// 实现Color接口的工厂
    /// </summary>
    public class ColorFactory : AbstractFactoryPattern
    {
        public override Color getColor(string color)
        {
            if (color == null)
            {
                return null;
            }
            if (color=="RED")
            {
                return new Red();
            }
      
            else if (color=="BLUE")
            {
                return new Blue();
            }
            return null;
        }

        public override Shape getShape(string shape)
        {
            return null;
        }
    }


    //选择进入那个工厂的工厂
    public class FactoryProudecer
    {
        public static AbstractFactoryPattern getFactory(string chioce)
        {
            if (chioce=="SHAPE")
            {
                return new ShapeFactory();
            }
            else if (chioce== "COLOR")
            {
                return new ColorFactory();
            }
            return null;
        }
    }

    //实现工厂调用
    public class AbstractFactoryPatternDemo
    {
        public void Use()
        {
            ///Shape工厂调用
            AbstractFactoryPattern shapeFactory = FactoryProudecer.getFactory("SHAPE");
            //在工厂找到要实现的类
            Shape shape = shapeFactory.getShape("CIRCLE");
            ///color工厂调用
            var a = shape.draw();
            Shape shape1 = shapeFactory.getShape("RECTANGLE");
            //调用 Rectangle 的 draw 方法
            a = shape1.draw();

            //Color 工厂调用
            AbstractFactoryPattern colorFactory = FactoryProudecer.getFactory("COLOR");
            //获取红色对象
            Color color1 = colorFactory.getColor("RED");
            a = color1.fill();
            Color color2 = colorFactory.getColor("BLUE");
            a = color2.fill();
        }
    }
}
