using System;

public abstract class Shape
{
    protected IRenderer Renderer;

    protected Shape(IRenderer renderer)
    {
        Renderer = renderer;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        Renderer.RenderCircle();
    }
}

public class Square : Shape
{
    public Square(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        Renderer.RenderSquare();
    }
}

public class Triangle : Shape
{
    public Triangle(IRenderer renderer) : base(renderer)
    {
    }

    public override void Draw()
    {
        Renderer.RenderTriangle();
    }
}

public interface IRenderer
{
    void RenderCircle();
    void RenderSquare();
    void RenderTriangle();
}

public class RasterRenderer : IRenderer
{
    public void RenderCircle()
    {
        Console.WriteLine("Drawing Circle as pixels");
    }

    public void RenderSquare()
    {
        Console.WriteLine("Drawing Square as pixels");
    }

    public void RenderTriangle()
    {
        Console.WriteLine("Drawing Triangle as pixels");
    }
}

public class VectorRenderer : IRenderer
{
    public void RenderCircle()
    {
        Console.WriteLine("Drawing Circle as vectors");
    }

    public void RenderSquare()
    {
        Console.WriteLine("Drawing Square as vectors");
    }

    public void RenderTriangle()
    {
        Console.WriteLine("Drawing Triangle as vectors");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Rendering shapes in raster format:");
        var rasterCircle = new Circle(new RasterRenderer());
        rasterCircle.Draw();

        var rasterSquare = new Square(new RasterRenderer());
        rasterSquare.Draw();

        var rasterTriangle = new Triangle(new RasterRenderer());
        rasterTriangle.Draw();

        Console.WriteLine("\nRendering shapes in vector format:");
        var vectorCircle = new Circle(new VectorRenderer());
        vectorCircle.Draw();

        var vectorSquare = new Square(new VectorRenderer());
        vectorSquare.Draw();

        var vectorTriangle = new Triangle(new VectorRenderer());
        vectorTriangle.Draw();
    }
}
