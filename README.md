
# Fortune

A no-nonsense, user-extensible `fortune-mod` replacement.

## Goals

- Sensible: I'm fed up with fortunes about men hating their wives.
- Straightforward: No weird formats. Plain text with `\n` escape sequences; easy to add or remove content.

This project was originally built in Rust, and I migrated it to C# primarily to
test out [bflat](https://github.com/bflattened/bflat).

## Installation

### Application

<details>
<summary>Release Binary</summary>

Copy the compiled binary from the [releases page](https://git.vwolfe.io/valerie/fortune-cs/releases)
to a directory in `$PATH`, such as `/usr/bin/`.

</details>

<details>
<summary>From Source</summary>

Clone the source repository and either use the prewritten [just](https://github.com/casey/just)
recipe with the command `just build`, or run `bflat build ./src/Program.cs` if
you'd rather set your build options manually.

</details>

### Base Fortunes

<details>
<summary>Release Tarball</summary>

Copy the `base-fortunes.tar.gz` tarball from the [releases page](https://git.vwolfe.io/valerie/fortune-cs/releases),
extract the archive using `tar xzf base-fortunes.tar.gz`, and move the
resulting `.txt` files to `/usr/share/fortune-cs/`.

</details>

<details>
<summary>From Source</summary>

Clone the source repository and copy the files from the `data/` directory to
`/usr/share/fortune-cs`.

</details>

## Dependencies

- [bflat](https://github.com/bflattened/bflat): Compiler
- [just](https://github.com/casey/just): Build recipe

