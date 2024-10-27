import React, { useState } from 'react'
import WorkResultTable from '../components/metrics/WorkResultTable';

function Metrics() {
    const [count, setCount] = useState(0)

    return (
        <>
            <div className="container">
                <br />
                <h1>İstatistikler</h1>
                <br />
                <WorkResultTable/>
            </div>
        </>
    )
}

export default Metrics