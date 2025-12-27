import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {
   const[xx, setActivities] = useState<Activity[]>([]);
   useEffect(() => {
        //fetch("https://localhost:6969/Activities/GetActivities") //it will fetch the data and will get in Json format
        //.then((response) => response.json()) //it will convert JSON to JS format
        //.then((data) => setActivities(data));
        axios.get<Activity[]>("https://localhost:6969/Activities/GetActivities") //here it will fetch JSON and convert to JS automatically, 
                                                                                // and it will know that the converted JS is of Activity type
        .then((x) => {
            setActivities(x.data);
        });

    }  , []);
    return (
        <>
            <Typography variant="h3">Activities</Typography>
            <List>
                {xx.map((activity)=>(
                    <ListItem key={activity.id}>
                        <ListItemText>{activity.title}</ListItemText>
                    </ListItem>
                ))}
            </List>
        </>
    );
}

export default App
