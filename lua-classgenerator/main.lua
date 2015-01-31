require("fileparser");
require("filewriter");
require("stringtools");
require("classparser");

lineFeed = fileparser.get_lines("classlist.txt");

classTable = fileparser.get_classes(lineFeed);

for _,class in pairs(classTable) do
	classparser.parseToCSh(class)
end