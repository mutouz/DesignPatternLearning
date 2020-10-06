using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternLearning
{
    /// <summary>
    /// 食品包装类
    /// </summary>
    public interface Item
    {
        public string name();
        /// <summary>
        /// 包装类型 可拓展类型
        /// </summary>
        /// <returns></returns>
        public Packing packing();
        public float price();
    }
    public interface Packing
    {
        public String pack();
    }
    /// <summary>
    /// 包装纸
    /// </summary>
    public class Wrapper : Packing
    {
        public string pack()
        {
            return "Wrapper";
        }
    }
    /// <summary>
    /// 使用多个简单的对象一步一步构建成一个复杂的对象。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
    /// </summary>
    public class BuilderPattern
    {
      
    }
}
