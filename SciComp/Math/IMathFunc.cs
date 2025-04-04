namespace SciComp.Math;

public interface IMathFunc
{
    IMathFunc Derivative();
    IMathFunc Integral(double c);
    double Evaluate(double x);
}