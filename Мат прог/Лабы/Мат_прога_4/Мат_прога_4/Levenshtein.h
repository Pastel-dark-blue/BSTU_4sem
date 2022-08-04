// - Levenshtein.h  
// -- дистанция   Левенштeйна (динамическое программирование)
int levenshtein(
	int lx,           // длина слова x 
	std::string x,   // слово x
	int ly,           // длина слова y
	std::string y    // слово y
);

// -- дистанция   Левенштeйна (рекурсия)
int levenshtein_r(
	int lx,           // длина строки x 
	std::string x,   // строка x
	int ly,           // длина строки y
	std::string y    // строка y
);
