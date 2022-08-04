// - Levenshtein.h  
// -- ���������   �������e��� (������������ ����������������)
int levenshtein(
	int lx,           // ����� ����� x 
	std::string x,   // ����� x
	int ly,           // ����� ����� y
	std::string y    // ����� y
);

// -- ���������   �������e��� (��������)
int levenshtein_r(
	int lx,           // ����� ������ x 
	std::string x,   // ������ x
	int ly,           // ����� ������ y
	std::string y    // ������ y
);
