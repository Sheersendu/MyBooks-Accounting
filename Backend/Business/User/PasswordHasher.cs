using System.Security.Cryptography;

namespace Backend.Business.User;

public static class PasswordHasher
{
	// Generate a salt of the specified size
	private static byte[] GenerateSalt(int saltSize)
	{
		byte[] salt = new byte[saltSize];
		using (var rng = RandomNumberGenerator.Create())
		{
			rng.GetBytes(salt);
		}

		return salt;
	}

	// Hash the password using PBKDF2 with a random salt
	public static string HashPassword(string password)
	{
		int saltSize = 16; // Choose an appropriate salt size
		int iterations = 10000; // Choose an appropriate number of iterations

		byte[] salt = GenerateSalt(saltSize);
		using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
		{
			byte[] hash = pbkdf2.GetBytes(32); // Choose an appropriate hash size
			byte[] saltedHash = new byte[saltSize + hash.Length];
			Buffer.BlockCopy(salt, 0, saltedHash, 0, saltSize);
			Buffer.BlockCopy(hash, 0, saltedHash, saltSize, hash.Length);
			return Convert.ToBase64String(saltedHash);
		}
	}

	// Verify if the entered password matches the hashed password
	public static bool VerifyPassword(string enteredPassword, string hashedPassword)
	{
		byte[] saltedHash = Convert.FromBase64String(hashedPassword);
		int saltSize = 16; // Size of the salt used during hashing

		byte[] salt = new byte[saltSize];
		Buffer.BlockCopy(saltedHash, 0, salt, 0, saltSize);

		using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
		{
			byte[] hash = pbkdf2.GetBytes(32); // Size of the hash
			for (int i = 0; i < hash.Length; i++)
			{
				if (hash[i] != saltedHash[saltSize + i])
					return false;
			}

			return true;
		}
	}
}