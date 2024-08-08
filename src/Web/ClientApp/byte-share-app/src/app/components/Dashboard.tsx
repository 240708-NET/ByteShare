import { useContext, useEffect } from 'react';

interface User {
    username: string;
    roleId: number;
}

type UserList = User[]

export const Dashboard = () => {
    const{username} = useContext{UserContext};
    const[userList, setUserList] = useState(null);

    useEffect(() => {

        //Call our backend here
        fetch('http://localhost:5094/api/Users/ListAllUsers', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(data => {
            setUserList(data);
        })
        .catch(err => console.error(err))

    }, [])

    return(
        <div>
            <h1>Welcome {username}</h1>
            <ul>
                {
                }
            </ul>
        </div>
    )
}