namespace Day_04
{
	public interface IValidatorRule
	{
		bool IsResponsible(string field);
		bool IsValid(string value);
	}
}