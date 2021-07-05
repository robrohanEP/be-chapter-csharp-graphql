## Getting Started

```
make clean
make install
make build
make start
```

open http://localhost:5000/graphql/

```gql
query {
  authors {
    id
    name
  }
}
```

```gql
mutation {
  addAuthor(input: { id: "1234", name: "Superfly" }) {
    author {
      name
    }
  }
}
```
