function UserList({ users }) {
  return (
    <div className="user-list">
      <h3>Users</h3>
      <ul>
        {users.map((u, i) => (
          <li key={i}>{u.displayName || u.email}</li>
        ))}
      </ul>
    </div>
  );
}
export default UserList;
