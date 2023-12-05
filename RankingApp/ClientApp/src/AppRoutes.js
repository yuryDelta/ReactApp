import { Counter } from "./components/Counter";
import { FetchGridData } from "./components/FetchGridData";
import { Home } from "./components/Home";


const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchGridData />
    },
];

export default AppRoutes;
