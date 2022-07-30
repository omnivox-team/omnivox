
map-tests: *.cs
	out=$(shell mktemp); \
	csc -out:$$out *.cs || exit 1; \
	mono $$out
