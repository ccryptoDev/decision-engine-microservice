EXCEPTION:
---------------
Internal.Cryptography.CryptoThrowHelper+WindowsCryptographicException: The system cannot find the file specified.

SOLUTION:
------------
Go to IIS Manager
Go to the application pool instance
Click advanced settings
Under Process model, set Load User Profile to true