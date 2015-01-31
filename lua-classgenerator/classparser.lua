require("classparsetable")
classparser = {}

function classparser.parseToCSh(classData)
	classCode = {}
	for _,v in pairs(classData) do
		tokenString = stringtools.tokenize(v)
		assert(classparsetable[tokenString[1]] ~= nil, "No class parse definition for token \"" .. tokenString[1] .. "\"")

		appendLines = classparsetable[tokenString[1]](tokenString);
		assert(type(appendLines) == "table");

		classCode = stringtools.mergestringtable(classCode, appendLines)
	end
end