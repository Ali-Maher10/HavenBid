type Args={
    status:"success" | "error" | "pending";
};

const ApiStatus=({status}:Args)=>{
    switch(status){
        case "error":
            return (
                <section className="api-status api-status--error" role="alert">
                    <div className="api-status__icon" aria-hidden="true">!</div>
                    <div className="api-status__copy">
                        <p className="api-status__eyebrow">Connection interrupted</p>
                        <h2>We couldn’t load the homes</h2>
                        <p>There was a problem reaching the data service. Please try again shortly.</p>
                    </div>
                </section>
            );
        case "pending":
            return (
                <section className="api-status api-status--pending" role="status" aria-live="polite">
                    <div className="api-status__loader" aria-hidden="true">
                        <span />
                    </div>
                    <div className="api-status__copy">
                        <p className="api-status__eyebrow">Just a moment</p>
                        <h2>Finding homes for you</h2>
                        <p>We’re bringing the latest listings into view.</p>
                    </div>
                    <div className="api-status__track" aria-hidden="true"><span /></div>
                </section>
            );
        case "success":
            return null;
    }
};

export default ApiStatus;