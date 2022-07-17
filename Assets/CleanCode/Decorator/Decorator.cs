using System.Collections;
using System.Collections.Generic;

//base interface
interface IPizza
{
    string GetPizza();
}
// concrete implementation
class Pizza : IPizza
{
    public string GetPizza()
    {
        return "This is a normal pizza";
    }
}

//base decorator 
class PizzaDecorator : IPizza
{
    private IPizza _pizza;

    public PizzaDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }
    
    
    public virtual string GetPizza()
    {
        return _pizza.GetPizza();
    }
}

// concrete decorators 

class CheeseDecorators : PizzaDecorator
{
    public CheeseDecorators(IPizza pizza) : base(pizza)
    {
         
    }
    
    public override string GetPizza()
    {
        var type = base.GetPizza();
        type += "with an extra cheese";
        return type;
    }
    
}

class TomatoDecorators : PizzaDecorator
{
    public TomatoDecorators(IPizza pizza) : base(pizza)
    {
         
    }
    
    public override string GetPizza()
    {
        var type = base.GetPizza();
        type += "with an extra tomato";
        return type;
    }
    
}

class OnionsDecorators : PizzaDecorator
{
    public OnionsDecorators(IPizza pizza) : base(pizza)
    {
         
    }
    
    public override string GetPizza()
    {
        var type = base.GetPizza();
        type += "with an extra onions";
        return type;
    }
    
}