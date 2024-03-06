
build:
	bflat build -o ./target/fortune-cs --no-reflection --no-stacktrace-data --no-globalization --no-debug-info --no-pie

fortunes:
	cd data & tar czf ../target/base-fortunes.tar.gz ./*.txt

