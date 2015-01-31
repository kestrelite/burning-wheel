--Each function in this file enters the classparsetable, which the classparser searches to find the right function.

classparsetable = {}

function classparsetable.NSP(tokString)
	return {} --No data to return - classparser takes care of this
end

function classparsetable.C(tokString) 
	assert(#tokString == 2, "Too much data to C")
	return {"class ".. tokString[2], "{"}
end

function classparsetable.EC(tokString)
	return {"}"}
end

function classparsetable.F(tokString)
	assert(#tokString >= 3, "Too little data to F")
	assert(#tokString <= 4, "Too much data to F")
	if(#tokString == 4) then 
		assert(not(string.match(tokString[4], "[^FGS]")), "Invalid token in F options")
		assert(#tokString[4] < 4, "No extraneous tokens allowed in F")
	end

	line = "public "
	if(#tokString == 4 and string.match(tokString[4], "[F]")) then
		line = line.."final "
	end

	addGet = string.match(tokString[4], "[G]");
	addSet = string.match(tokString[4], "[S]");
	if(addGet == nil) then addGet = false else addGet = true end
	if(addSet == nil) then addSet = false else addSet = true end

	line = line..tokString[2].." "..tokString[3];
	if(#tokString == 3 or (not(addSet) and not(addGet))) then return {line..";"} end

	line = line.." { "
	if(addSet) then line = line.."set; " end
	if(addGet) then line = line.."get; " end
	line = line.."}"

	return {line};
end

function classparsetable._genFunc(tokString, pubPriv)
	signature = ""
	for i=4,#tokString,1 do
		signature = signature..tokString[i].." arg"..(i-3)
	end
	
	return {pubPriv.." "..tokString[2].." "..tokString[3].."("..signature..")","{","}"}
end

function classparsetable.PU(tokString)
	assert(#tokString >= 3, "Tokens invalid for PU")
	return classparsetable._genFunc(tokString, "public")
end

function classparsetable.PR(tokString) 
	assert(#tokString >= 3, "Tokens invalid for PR")
	return classparsetable._genFunc(tokString, "private")
end

