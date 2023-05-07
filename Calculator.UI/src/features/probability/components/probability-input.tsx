type ProbabilityInputProps = {
    value: number;
    onChange: (value: number) => void;
    name: string;
}

const ProbabilityInput = (props: ProbabilityInputProps) => {

    const { onChange, value } = props;
    return (
        <span>
            <label htmlFor={props.name}>Probability {props.name}</label>
            <input
                id={props.name}
                type={"number"}
                value={value}
                onChange={(event) => onChange(parseFloat(event.currentTarget.value))}
                max={1.0}
                min={0.0}
                step={0.01} />
        </span>
    );
};

export default ProbabilityInput;