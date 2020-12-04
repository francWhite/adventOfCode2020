using System.Collections.Generic;
using System.Linq;
using Day_04.ValidationRules;

namespace Day_04
{
	internal class PassportValidator
	{
		private readonly IReadOnlyList<IValidatorRule> _validatorRules = new List<IValidatorRule>
		{
			new ByrValidator(),
			new EclValidator(),
			new EyrValidator(),
			new HclValidator(),
			new HgtValidator(),
			new IyrValidator(),
			new PidValidator()
		};

		public bool IsValid(Dictionary<string, string> passport)
		{
			foreach (var (field, value) in passport)
			{
				var rule = _validatorRules.Single(v => v.IsResponsible(field));
				if (!rule.IsValid(value))
				{
					return false;
				}
			}

			return true;
		}
	}
}