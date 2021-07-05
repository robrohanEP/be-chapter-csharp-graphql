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
